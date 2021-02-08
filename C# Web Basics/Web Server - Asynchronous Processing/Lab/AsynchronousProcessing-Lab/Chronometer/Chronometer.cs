using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private  List<String> laps;

        public Chronometer()
        {
            this.Stopwatch = new Stopwatch();
            this.laps = new List<string>();
        }


        public string GetTime => Stopwatch.Elapsed.ToString(@"mm\:ss\.ffff");

        private Stopwatch Stopwatch { get;}

        public List<string> Laps => laps;

        public string Lap()
        {
            var lap = this.Stopwatch.Elapsed.ToString(@"mm\:ss\.ffff");

            laps.Add(lap);

            return lap;
        }

        public void Reset()
        {
            this.laps.Clear();
        }

        public void Start()
        {
          Task.Run(() => this.Stopwatch.Start());
        }

        public void Stop()
        {
            this.Stopwatch.Stop();
        }

        public string GetLaps()
        {

            if (laps.Count == 0)
            {
                return "No laps!";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Laps:");
            foreach (var lap in laps)
            {
                sb.AppendLine(lap);
            }             

            return sb.ToString().TrimEnd();
        }
    }
}
