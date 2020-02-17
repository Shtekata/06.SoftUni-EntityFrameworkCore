namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDtos = JsonConvert.DeserializeObject<MovieImportDto[]>(jsonString);
            var movies = new List<Movie>();
            var sb = new StringBuilder();

            foreach (var x in moviesDtos)
            {
                if (IsValid(x))
                {
                    var movie = new Movie()
                    {
                        Title = x.Title,
                        Genre = x.Genre,
                        Duration = x.Duration,
                        Rating = x.Rating,
                        Director = x.Director
                    };

                    movies.Add(movie);
                    context.Movies.AddRange(movies);
                    sb.AppendLine(String.Format(SuccessfulImportMovie, x.Title, x.Genre, x.Rating.ToString("f2")));
                }
                else sb.AppendLine(ErrorMessage);
            }
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var objects = JsonConvert.DeserializeObject<HallSeatsImportDto[]>(jsonString);
            var sb = new StringBuilder();

            foreach (var x in objects)
            {
                if (IsValid(x))
                {
                    var hall = new Hall()
                    {
                        Name = x.Name,
                        Is4Dx = x.Is4Dx,
                        Is3D = x.Is3D
                    };

                    context.Halls.Add(hall);
                    AddSeatsInDatabase(context, hall.Id, x.Seats);
                    var projectionType = GetProjectionType(hall);
                    sb.AppendLine(string.Format(SuccessfulImportHallSeat, x.Name, projectionType, x.Seats));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ProjectionImportDto[]), new XmlRootAttribute("Projections"));
            var objects = (ProjectionImportDto[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();

            foreach (var x in objects)
            {
                if (IsValid(x) && IsValidMovieId(context, x.MovieId) && IsValidHallId(context, x.HallId))
                {
                    var projection = new Projection
                    {
                        MovieId = x.MovieId,
                        HallId = x.HallId,
                        DateTime = DateTime.ParseExact(x.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                    };

                    context.Projections.Add(projection);
                    var dateTimeRes = projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    sb.AppendLine(string.Format(SuccessfulImportProjection, projection.Movie.Title, dateTimeRes));
                }
                else sb.AppendLine(ErrorMessage);
            }
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(CustomerImportDto[]), new XmlRootAttribute("Customers"));
            var objects = (CustomerImportDto[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();

            foreach (var x in objects)
            {
                if (IsValid(x))
                {
                    var customer = new Customer
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Age = x.Age,
                        Balance = x.Balance,
                    };

                    context.Customers.Add(customer);
                    AddCustomerTickets(context, customer.Id, x.Tickets);
                    sb.AppendLine(String.Format(SuccessfulImportCustomerTicket, x.FirstName, x.LastName, x.Tickets.Length));
                }
                else sb.AppendLine(ErrorMessage);
            }

            context.SaveChanges();
            return sb.ToString().Trim();
        }

        private static void AddCustomerTickets(CinemaContext context, int id, TicketCustomerImportDto[] ticketsDto)
        {
            var tickets = new List<Ticket>();

            foreach (var y in ticketsDto)
            {
                if (IsValid(y))
                {
                    var ticket = new Ticket
                    {
                        CustomerId = id,
                        ProjectionId = y.ProjectionId,
                        Price = y.Price
                    };

                    tickets.Add(ticket);
                }
            }

            context.Tickets.AddRange(tickets);
            context.SaveChanges();
        }

        private static bool IsValidHallId(CinemaContext context, int hallId)
        {
            return context.Halls.Any(x => x.Id == hallId);
        }

        private static bool IsValidMovieId(CinemaContext context, int movieId)
        {
            return context.Movies.Any(x => x.Id == movieId);
        }

        private static bool IsValid(object x)
        {
            var validator = new ValidationContext(x);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(x, validator, validationResult, true);
            return result;
        }

        private static void AddSeatsInDatabase(CinemaContext context, int id, int seatsCount)
        {
            var seats = new List<Seat>();

            for (int i = 0; i < seatsCount; i++)
            {
                seats.Add(new Seat() { HallId = id });
            }

            context.Seats.AddRange(seats);
            context.SaveChanges();
        }

        private static string GetProjectionType(Hall hall)
        {
            var result = "Normal";

            if (hall.Is4Dx && hall.Is3D) result = "4Dx/3D";
            else if (hall.Is3D) result = "3D";
            else if (hall.Is4Dx) result = "4Dx";

            return result;
        }

    }
}