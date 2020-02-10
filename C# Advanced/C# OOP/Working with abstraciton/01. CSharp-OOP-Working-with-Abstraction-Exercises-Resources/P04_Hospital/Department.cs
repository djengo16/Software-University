using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace P04_Hospital
{
    class Department
    {
        public Department(string name)
        {
            Name = name;
            Rooms = new Room[20];
        }

        public string Name { get; set; }
        public Room[] Rooms { get; set; }


        public void AddPeopleToRoom(Patient patient)
        {
            var currentRoom = Rooms.FirstOrDefault(r => !r.isFull);
            if (currentRoom != null)
            {
                currentRoom.Patients.Add(patient);
            }
        }

    }
}
