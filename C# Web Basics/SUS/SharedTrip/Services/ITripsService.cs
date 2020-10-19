using SharedTrip.ViewModels;
using System.Collections;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void AddTrip(TripInputModel tripInput);

        ICollection<TripViewModel> GetAll();

        public TripDetailsViewModel GetTripDetails(string tripId);

        public bool AddTripToUser(string tripId, string userId);
    }
}
