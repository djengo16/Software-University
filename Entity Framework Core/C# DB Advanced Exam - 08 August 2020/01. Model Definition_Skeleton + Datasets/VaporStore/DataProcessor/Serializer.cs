namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
	using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
	using VaporStore.Data.Models.Enums;
	using VaporStore.DataProcessor.Dto.Export;

	public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var genres = context
				.Genres
				.ToArray()
				.Where(g => genreNames.Contains(g.Name))
				.Select(g => new
				{
					Id = g.Id,
					Genre = g.Name,
					Games = g.Games
						.Where(ga => ga.Purchases.Any())
						.Select(ga => new
						{
							Id = ga.Id,
							Title = ga.Name,
							Developer = ga.Developer.Name,
							Tags = String.Join(", ", ga.GameTags
								.Select(gt => gt.Tag.Name)
								.ToArray()),
							Players = ga.Purchases.Count
						})
						.OrderByDescending(ga => ga.Players)
						.ThenBy(ga => ga.Id)
						.ToArray(),
					TotalPlayers = g.Games.Sum(ga => ga.Purchases.Count)
				})
				.OrderByDescending(g => g.TotalPlayers)
				.ThenBy(g => g.Id)
				.ToArray();

			string json = JsonConvert.SerializeObject(genres, Newtonsoft.Json.Formatting.Indented);

			return json;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{

			var usersPurchase = context.Users
				.ToArray()
				.Where(x => x.Cards.Any(c => c.Purchases.Any()))
				.Select(x => new ExportUserPurchase
				{
					Username = x.Username,
					Purchases = context.Purchases
					.ToArray()
					.Where(p => p.Type == (PurchaseType)Enum.Parse(typeof(PurchaseType), storeType)
					&& p.Card.User.Username == x.Username)
					.OrderBy(p => p.Date)
					.Select(p => new ExportPurchaseDTO
					{
						Card = p.Card.Number,
						Cvc = p.Card.Cvc,
						Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
						Game = new ExportGameDTO
						{
							Title = p.Game.Name,
							Genre = p.Game.Genre.Name,
							Price = p.Game.Price
						}
					})
				   .ToArray()
				   ,
					TotalSpent = context.Purchases
					.ToArray()
					.Where(p => p.Type == (PurchaseType)Enum.Parse(typeof(PurchaseType), storeType)
					&& p.Card.User.Username == x.Username)
					.Sum(p => p.Game.Price)
				})
				.Where(x => x.Purchases.Length > 0)
				.OrderByDescending(x => x.TotalSpent)
				.ThenBy(x => x.Username)
				.ToArray();
			;
			StringBuilder sb = new StringBuilder();

			var attr = new XmlRootAttribute("Users");

			var namespaces = new XmlSerializerNamespaces(new[]
			{
				new XmlQualifiedName("","")
			});

			var serializer = new XmlSerializer(typeof(ExportUserPurchase[]), attr);

			serializer.Serialize(new StringWriter(sb), usersPurchase, namespaces);

			return sb.ToString().TrimEnd();
		}
	}
}