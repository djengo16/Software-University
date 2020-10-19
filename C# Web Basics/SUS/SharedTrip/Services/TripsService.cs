using SharedTrip.Data;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext database;

        public TripsService(ApplicationDbContext database)
        {
            this.database = database;
        }
        public void AddTrip(TripInputModel tripInput)
        {
            database.Trips.Add(new Trip
            {
                StartPoint = tripInput.StartPoint,
                EndPoint = tripInput.EndPoint,
                DepartureTime = DateTime.Parse(tripInput.DepartureTime),
                ImgPath = tripInput.ImagePath,
                Seats = tripInput.Seats,
                Description = tripInput.Description,
            });
            database.SaveChanges();
        }

        public ICollection<TripViewModel> GetAll()
        {
            return database.Trips.Select(x => new TripViewModel
            {
                TripId = x.Id,
                StartingPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Seats = x.Seats
            })
            .ToList();
               
        }

        public TripDetailsViewModel GetTripDetails(string tripId)
        {
            return database.Trips.Where(x => x.Id == tripId)
                .Select(x => new TripDetailsViewModel
                {
                    TripId = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Description = x.Description,
                    ImgPath = x.ImgPath,
                    Seats = x.Seats
                })
                .FirstOrDefault();
                
        }

        public bool AddTripToUser(string tripId,string userId)
        {
            if(database.UserTrips.Any(x => x.TripId == tripId && x.UserId == userId))
            {
                return false;
            }

            var trip = this.database.Trips.FirstOrDefault(x => x.Id == tripId);

            if (trip.Seats != 0)
            {
                trip.Seats -= 1;

                this.database.UserTrips.Add(new UserTrip
                {
                    TripId = tripId,
                    UserId = userId,
                });
                database.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
