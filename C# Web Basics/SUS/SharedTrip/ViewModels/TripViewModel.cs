using SharedTrip.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SharedTrip.ViewModels
{
    public class TripViewModel : Trip
    {
        public string TripId { get; set; }
        public string StartingPoint { get; set; }

        public string DepartureTimeAsString => this.DepartureTime.ToString("s", CultureInfo.GetCultureInfo("bg-BG"));

        public int AvailableSeats => this.Seats - UsedSeats;

        public int UsedSeats { get; set; }
    }
}
