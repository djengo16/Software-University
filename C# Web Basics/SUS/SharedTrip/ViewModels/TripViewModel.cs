using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.ViewModels
{
    public class TripViewModel
    {
        public string TripId { get; set; }
        public string StartingPoint { get; set; }

        public string EndPoint { get; set; }

        public string DepartureTime { get; set; }

        public int Seats { get; set; }
    }
}
