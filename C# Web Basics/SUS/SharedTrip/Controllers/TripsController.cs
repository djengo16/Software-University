using SharedTrip.Services;
using SharedTrip.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;


namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var trips = tripsService.GetAll();
            return this.View(trips);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost("/Trips/Add")]
        public HttpResponse Add(TripInputModel tripInputViewModel)
        {
            
            var check = DateTime.TryParse(tripInputViewModel.DepartureTime, out _);

            if (string.IsNullOrEmpty(tripInputViewModel.StartPoint) 
                || string.IsNullOrEmpty(tripInputViewModel.EndPoint)
                || !DateTime.TryParse(tripInputViewModel.DepartureTime,out _))
            {
                return this.Redirect("/Trips/Add");
            }

            if(tripInputViewModel.Seats < 2 || tripInputViewModel.Seats > 6)
            {
                return this.Redirect("/Trips/Add");
            }

            if(tripInputViewModel.Description.Length > 80 ||
                string.IsNullOrEmpty(tripInputViewModel.Description))
            {
                return this.Redirect("/Trips/Add");
            }

            tripsService.AddTrip(tripInputViewModel);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Details(string tripId)
        {

            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var tripDetails = tripsService.GetTripDetails(tripId);

            return this.View(tripDetails);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            var userId = this.GetUserId();

            if (tripsService.AddTripToUser(tripId, userId))
            {
                return this.Redirect("/");
            }

            return this.Details(tripId);
        }
    }
}
