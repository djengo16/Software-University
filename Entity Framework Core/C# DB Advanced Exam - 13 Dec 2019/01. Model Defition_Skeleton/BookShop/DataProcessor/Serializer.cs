namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var targetAuthors = context.Authors
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Books = x.AuthorsBooks
                    .OrderByDescending(b => b.Book.Price)
                    .Select(ab => new
                    {
                        BookName = ab.Book.Name,
                        BookPrice = ab.Book.Price.ToString("f2")
                    })
                    .ToList()
                }).ToList()
                .OrderByDescending(x => x.Books.Count)
                .ThenBy(x => x.AuthorName)
                .ToList();

            string json = JsonConvert.SerializeObject(targetAuthors, Formatting.Indented);
            return json;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            StringBuilder sb = new StringBuilder();

            var attr = new XmlRootAttribute("Books");

            var books = context.Books
                .Where(x => x.Genre == (Genre)3)
                .Where(x => x.PublishedOn < date)
                .Select(x => new ExportBookDTO
                {
                    Pages = x.Pages,
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .ToList()
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.Date)
                .Take(10)
                .ToArray();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            var serializer = new XmlSerializer(typeof(ExportBookDTO[]), attr);

            serializer.Serialize(new StringWriter(sb), books, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}