using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public double DifferenceBetweenTwoDates(string start,string end)
        {
            DateTime firstDate = DateTime.Parse(start);
            DateTime secondDate = DateTime.Parse(end);

            double difference = (firstDate - secondDate).TotalDays;
            return difference;
        }
    }
}
