using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    class Hospital
    {
        public Hospital()
        {
            Departments = new List<Department>();
            Doctors = new List<Doctor>();
        }

        public List<Department> Departments { get; set; }
        public List<Doctor> Doctors { get; set; }


    }
}
