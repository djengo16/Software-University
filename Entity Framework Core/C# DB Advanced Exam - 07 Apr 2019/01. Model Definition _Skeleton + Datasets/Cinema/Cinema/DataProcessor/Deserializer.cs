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
    using Castle.Core.Internal;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Microsoft.EntityFrameworkCore.Migrations.Operations;
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
            StringBuilder sb = new StringBuilder();

            ImportMovieDTO[] importedMovies = JsonConvert.DeserializeObject<ImportMovieDTO[]>(jsonString);

            List<Movie> validMovies = new List<Movie>();
            ;
            foreach (var movieDTO in importedMovies)
            {
                if (!IsValid(movieDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //Check If some of the properties missing
                if (
                     (movieDTO.Title.IsNullOrEmpty() ||
                      movieDTO.Genre.IsNullOrEmpty() ||
                      movieDTO.Duration.IsNullOrEmpty() ||
                      Double.IsNaN(movieDTO.Rating) ||
                      movieDTO.Director.IsNullOrEmpty()
                      ))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (validMovies.Any(m => m.Title == movieDTO.Title))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }



                Movie movie = new Movie
                {
                    Title = movieDTO.Title,
                    Genre = (Genre)Enum.Parse(typeof(Genre), movieDTO.Genre),
                    Rating = movieDTO.Rating,
                    Duration = TimeSpan.Parse(movieDTO.Duration),
                    Director = movieDTO.Director
                };

                validMovies.Add(movie);
                sb.AppendLine(String.Format(SuccessfulImportMovie,
                    movie.Title, movie.Genre.ToString(), movie.Rating.ToString("f2")));
            }
            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportHallSeatsDTO[] importedHallSeats = JsonConvert.DeserializeObject<ImportHallSeatsDTO[]>(jsonString);

            List<Hall> validHalls = new List<Hall>();

            foreach (var hallDTO in importedHallSeats)
            {
                if (!IsValid(hallDTO))
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                //Create hall if everything is valid

                Hall validHall = new Hall
                {
                    Name = hallDTO.Name,
                    Is4Dx = hallDTO.Is4Dx,
                    Is3D = hallDTO.Is3D,
                };

                //Create seats
                List<Seat> seats = new List<Seat>();

                for (int i = 0; i < hallDTO.Seats; i++)
                {
                    seats.Add(new Seat
                    {
                        Hall = validHall
                    });
                }

                validHall.Seats = seats;

                if (validHall.Seats.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validHalls.Add(validHall);
                string projectionType = "";

                // Check the projection Type
                if (validHall.Is4Dx && validHall.Is3D) { projectionType = "4Dx/3D"; }
                else
                {
                    if (validHall.Is3D) { projectionType = "3D"; }

                    if (validHall.Is4Dx) { projectionType = "4Dx"; }

                    if (projectionType.IsNullOrEmpty()) { projectionType = "Normal"; }
                }
                //End of checking projection Type

                sb.AppendLine(String.Format(SuccessfulImportHallSeat, validHall.Name, projectionType, validHall.Seats.Count));
            }
            context.Halls.AddRange(validHalls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportProjectionDTO[]), new XmlRootAttribute("Projections"));

            StringBuilder sb = new StringBuilder();

            using (StringReader stringReader = new StringReader(xmlString))
            {
                ImportProjectionDTO[] importedProjectionsDTO =
                    (ImportProjectionDTO[])serializer.Deserialize(stringReader);

                var validProjections = new List<Projection>();

                foreach (var projectionDTO in importedProjectionsDTO)
                {

                    if (!IsValid(projectionDTO))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (!context.Movies.Any(x => x.Id == projectionDTO.MovieId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (!context.Halls.Any(x => x.Id == projectionDTO.HallId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Projection validProjection = new Projection
                    {
                        MovieId = projectionDTO.MovieId,
                        HallId = projectionDTO.HallId,
                        Movie = context.Movies.FirstOrDefault(x => x.Id == projectionDTO.MovieId),
                        Hall = context.Halls.FirstOrDefault(x => x.Id == projectionDTO.HallId),
                        DateTime = DateTime.Parse(projectionDTO.DateTime, CultureInfo.InvariantCulture)
                    };

                    validProjections.Add(validProjection);

                    sb.AppendLine(String.Format
                        (SuccessfulImportProjection, validProjection.Movie.Title,
                        validProjection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
                }
                context.Projections.AddRange(validProjections);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }

        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportCustomerDTO[]), new XmlRootAttribute("Customers"));

            StringBuilder sb = new StringBuilder();

            using (StringReader stringReader = new StringReader(xmlString))
            {
                ImportCustomerDTO[] importCustomerDTOs =
                    (ImportCustomerDTO[])serializer.Deserialize(stringReader);

                var validCustomers = new List<Customer>();

                foreach (var customerDTO in importCustomerDTOs)
                {
                    if (!IsValid(customerDTO))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Customer validCustomer = new Customer
                    {
                        FirstName = customerDTO.FirstName,
                        LastName = customerDTO.LastName,
                        Age = customerDTO.Age,
                        Balance = customerDTO.Balance
                    };

                    foreach (var ticketDTO in customerDTO.Tickets)
                    {
                        if (!IsValid(ticketDTO))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if(!context.Projections.Any(x => x.Id == ticketDTO.ProjectionId))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        Ticket validTicket = new Ticket
                        {
                            ProjectionId = ticketDTO.ProjectionId,
                            Price = ticketDTO.Price,
                            Customer = validCustomer
                        };

                        validCustomer.Tickets.Add(validTicket);
                    }
                    sb.AppendLine(String.Format(SuccessfulImportCustomerTicket
                        , validCustomer.FirstName, validCustomer.LastName,validCustomer.Tickets.Count));
                    validCustomers.Add(validCustomer);
                }
                context.Customers.AddRange(validCustomers);
                context.SaveChanges();

            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}