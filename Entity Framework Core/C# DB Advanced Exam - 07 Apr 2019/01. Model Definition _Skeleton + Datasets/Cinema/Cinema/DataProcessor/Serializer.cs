namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(x => x.Rating >= rating)
                .Where(x => x.Projections.Any(p => p.Tickets.Count > 0))
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("f2"),
                    TotalIncomes = x.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("f2"),
                    Customers = x.Projections
                    .SelectMany(p => p.Tickets
                    .Select(t => new
                    {
                        FirstName = t.Customer.FirstName,
                        LastName = t.Customer.LastName,
                        Balance = t.Customer.Balance.ToString("f2")
                    }))
                    .OrderByDescending(t => t.Balance)
                    .ThenBy(t => t.FirstName)
                    .ThenBy(t => t.LastName)
                    .ToList()
                })
                .Take(10)
                .ToList();

            string json = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);
            return json;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Where(x => x.Age >= age)
                .Select(x => new ExportCustomerDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.FirstName,
                    SpentMoney = x.Tickets.Sum(t => t.Price).ToString("f2"),
                    SpentTime = TimeSpan.FromSeconds(x.Tickets.Sum(t => t.Projection.Movie.Duration.TotalSeconds)).ToString(@"hh\:mm\:ss")
                })
                .ToList()
                .OrderByDescending(x => decimal.Parse(x.SpentMoney))
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            var attr = new XmlRootAttribute("Customers");

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            var serializer = new XmlSerializer(typeof(List<ExportCustomerDTO>), attr);

            serializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}