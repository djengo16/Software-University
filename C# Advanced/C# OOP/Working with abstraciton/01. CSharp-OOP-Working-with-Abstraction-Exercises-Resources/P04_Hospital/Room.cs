using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    class Room
    {
        public Room()
        {
            this.Patients = new List<Patient>();
        }

        public bool isFull => this.Patients.Count == 3;

       public List<Patient> Patients { get; set; }
    }
}
