using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    class Doctor
    {
        public Doctor(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
            Patients = new List<Patient>();
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FullName => FirstName + " " + SecondName;
        public List<Patient> Patients { get; set; }
    }
}
