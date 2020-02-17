namespace Cinema.DataProcessor
{
    using System;
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
                .Where(x => x.Rating >= rating && x.Projections.Any(y => y.Tickets.Count > 0))
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Projections.Sum(y => y.Tickets.Sum(z => z.Price)))
                .Select(x => new MovieExportDto
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("f2"),
                    TotalIncomes = x.Projections.Sum(y => y.Tickets.Sum(z => z.Price)).ToString("f2"),
                    Customers = x.Projections
                                 .SelectMany(y => y.Tickets)
                                 .Select(z => z.Customer)
                                 .Select(a => new CustomersMovieExportDto
                                 {
                                     FirstName = a.FirstName,
                                     LastName = a.LastName,
                                     Balance = a.Balance.ToString("f2")
                                 })
                                 .OrderByDescending(a => a.Balance)
                                 .ThenBy(a => a.FirstName)
                                 .ThenBy(a => a.LastName)
                                 .ToList()
                })
                .Take(10)
                .ToList();

            var res = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);
            return res;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context
                .Customers
                .Where(x => x.Age >= age)
                .OrderByDescending(x => x.Tickets.Sum(y => y.Price))
                .Take(10)
                .Select(x => new CustomerExportDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = x.Tickets.Sum(y => y.Price).ToString("f2"),
                    //SpentTime = new DateTime(x.Tickets.Sum(y => y.Projection.Movie.Duration.Ticks)).ToString(@"hh\:mm\:ss")
                    SpentTime = TimeSpan.FromSeconds(x.Tickets.Sum(y => y.Projection.Movie.Duration.TotalSeconds)).ToString(@"hh\:mm\:ss")
                })
                .ToArray();

            var xmlserializer = new XmlSerializer(typeof(CustomerExportDto[]), new XmlRootAttribute("Customers"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlserializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().Trim();
        }
    }
}