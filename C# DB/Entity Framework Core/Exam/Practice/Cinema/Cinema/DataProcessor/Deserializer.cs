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
    using Cinema.Data.Models.Enums;
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
            var jsonMovies = JsonConvert.DeserializeObject<List<Movie>>(jsonString);

            var movies = new List<Movie>();

            var sb = new StringBuilder();

            foreach (var movie in jsonMovies)
            {
            //    if (IsValid(movie))
            //    {

            //    }


                var validGenre = Enum.IsDefined(typeof(Genre), movie.Genre);
                var validTitle = Validation(movie.Title);
                var validDirector = Validation(movie.Director);
                var validDuration = movie.Dudation != null;
                var validRating = movie.Rating >= 1 && movie.Rating <= 10;
                var movieExists = context.Movies.Any(x => x.Id == movie.Id);

                if (!movieExists)
                {
                    if (validGenre && validTitle && validDirector && validDuration && validRating)
                    {
                        movies.Add(movie);
                        sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre.ToString(), movie.Rating.ToString("f2")));
                    }

                    else
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                }

                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var res = Validator.TryValidateObject(obj, validator, validationRes, true);

            return res;
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var jsonHalls = JsonConvert.DeserializeObject<List<HallImportDTO>>(jsonString);

            var halls = new List<Hall>();

            var sb = new StringBuilder();

            foreach (var hall in jsonHalls)
            {
                var isNameValid = Validation(hall.Name);

                var projectionType = string.Empty;

                if (isNameValid && hall.SeatsCount > 0)
                {
                    if (hall.Is4Dx && hall.Is3D == false)
                    {
                        projectionType = "4Dx";
                    }

                    else if (hall.Is3D && hall.Is4Dx == false)
                    {
                        projectionType = "3D";
                    }

                    else if (hall.Is4Dx && hall.Is3D)
                    {
                        projectionType = "4Dx/3D";
                    }

                    else
                    {
                        projectionType = "Normal";
                    }

                    sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, projectionType, hall.SeatsCount));

                    var currentHall = new Hall
                    {
                        Name = hall.Name,
                        Is3D = hall.Is3D,
                        Is4Dx = hall.Is4Dx,
                        Seats = new List<Seat>()
                    };

                    for (int i = 0; i < hall.SeatsCount; i++)
                    {
                        currentHall.Seats.Add(new Seat());
                    }

                    halls.Add(currentHall);
                }

                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ImportProjectionsDTO>), new XmlRootAttribute("Projections"));

            var ProjectionsDTO = (List<ImportProjectionsDTO>)xmlSerializer.Deserialize(new StringReader(xmlString));

            var projections = new List<Projection>();

            var sb = new StringBuilder();

            foreach (var proj in ProjectionsDTO)
            {
                var movie = context.Movies.FirstOrDefault(m => m.Id == proj.MovieId);
                var hall = context.Halls.FirstOrDefault(h => h.Id == proj.HallId);

                if (movie != null && hall != null)
                {

                    var projection = new Projection
                    {
                        MovieId = proj.MovieId,
                        HallId = proj.HallId,
                        DateTime = DateTime.Parse(proj.DateTime)
                    };

                    sb.AppendLine(string.Format(SuccessfulImportProjection, movie.Title, projection.DateTime.ToString(@"MM/dd/yyyy"), CultureInfo.InvariantCulture));

                    projection.Movie = movie;
                    projection.Hall = hall;

                    projections.Add(projection);
                }

                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<CustomerImportDTO>), new XmlRootAttribute("Customers"));
            var customersDTO = (List<   >)xmlSerializer.Deserialize(new StringReader(xmlString));

            var customers = new List<Customer>();

            var sb = new StringBuilder();

            foreach (var cust in customersDTO)
            {
                var isFirstNameValid = Validation(cust.FirstName);
                var isLastNameValid = Validation(cust.LastName);
                var isAgeValid = cust.Age >= 12 && cust.Age <= 110;
                var isBalanceValid = cust.Balance >= 0.01m;

                if (isFirstNameValid
                    && isLastNameValid
                    && isAgeValid
                    && isBalanceValid)
                {
                    var customer = new Customer
                    {
                        FirstName = cust.FirstName,
                        LastName = cust.LastName,
                        Age = cust.Age,
                        Balance = cust.Balance,
                        Tickets = new List<Ticket>()
                    };

                    foreach (var tic in cust.Tickets)
                    {
                        var ticket = new Ticket
                        {
                            Customer = customer,
                            Price = tic.Price,
                            ProjectionId = tic.ProjectionId
                        };

                        customer.Tickets.Add(ticket);
                    }

                    customers.Add(customer);

                    sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count));
                }
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }



        public static bool Validation(string input)
        {
            var inputLenght = input.Length;

            return inputLenght >= 3 && inputLenght <= 20;
        }
    }
}