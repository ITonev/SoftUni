﻿namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
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
                var validGenre = Enum.IsDefined(typeof(Genre), movie.Genre);
                var validTitle = isValid(movie.Title);
                var validDirector = isValid(movie.Director);
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

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var jsonHalls = JsonConvert.DeserializeObject<List<HallImportDTO>>(jsonString);

            var halls = new List<Hall>();

            var sb = new StringBuilder();

            foreach (var hall in jsonHalls)
            {
                var isNameValid = isValid(hall.Name);

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
            throw new NotImplementedException();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static bool isValid(string input)
        {
            var inputLenght = input.Length;

            return inputLenght >= 3 && inputLenght <= 20;
        }
    }
}