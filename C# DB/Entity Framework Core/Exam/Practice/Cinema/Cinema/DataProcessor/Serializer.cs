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
            var movies = context
                .Movies
                .Where(r => r.Rating >= rating && r.Projections.Any(t => t.Tickets.Count >= 1))
                .OrderByDescending(r => r.Rating)
                .ThenByDescending(p => p.Projections.Sum(t => t.Tickets.Sum(pc => pc.Price)))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("F2"),
                    TotalIncomes = x.Projections.Sum(t => t.Tickets.Sum(p => p.Price)).ToString("F2"),
                    Customers = x.Projections.SelectMany(t => t.Tickets).Select(c => new
                    {
                        FirstName = c.Customer.FirstName,
                        LastName = c.Customer.LastName,
                        Balance = c.Customer.Balance.ToString("F2"),
                    })
                        .OrderByDescending(b => b.Balance)
                        .ThenBy(f => f.FirstName)
                        .ThenBy(l => l.LastName)
                        .ToArray()
                })
                .Take(10)
                .ToArray();

            var jsonString = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);

            return jsonString;

        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context
                .Customers
                .Where(a => a.Age >= age)
                .OrderByDescending(x => x.Tickets.Sum(p => p.Price))
                .Take(10)
                .Select(x => new ExportCustomerDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = x.Tickets.Sum(p => p.Price).ToString("F2"),
                    //SpentTime = TimeSpan.FromSeconds(
                    //        x.Tickets.Sum(s => s.Projection.Movie.Dudation.TotalSeconds))
                    //    .ToString(@"hh\:mm\:ss")
                    SpentTime = new DateTime(x.Tickets.Sum(p=>p.Projection.Movie.Dudation.Ticks)).ToString(@"hh\:mm\:ss")
                
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCustomerDTO[]), new XmlRootAttribute("Customers"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();


            //var customers = context
            //    .Customers
            //    .Where(x => x.Age >= age)
            //    .OrderByDescending(x => x.Tickets.Sum(a=>a.Price))
            //    .Select(x => new ExportCustomerDTO
            //    {
            //        FirstName = x.FirstName,
            //        LastName = x.LastName,
            //        SpentMoney = x.Tickets.Sum(t => t.Price).ToString("F2"),
            //        SpentTime = TimeSpan.FromMilliseconds(x.Tickets.Sum(a => a.Projection.Movie.Dudation.TotalMilliseconds)).ToString(@"hh\:mm\:ss")
            //    })
            //    .Take(10)
            //    .ToList();

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportCustomerDTO>), new XmlRootAttribute("Customers"));



            //var sb = new StringBuilder();

            //xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            //return sb.ToString().TrimEnd();
        }
    }
}