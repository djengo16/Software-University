using System;
using System.Collections.Generic;
using System.Linq;


namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] currentStudent = command.Split().ToArray();
               Student student = new Student(currentStudent[0], currentStudent[1], int.Parse(currentStudent[2]), currentStudent[3]);
                bool ifExists = false;
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].Name == student.Name && student.LastName == students[i].LastName)
                    {
                        students[i].Age = student.Age;
                        students[i].HomeTown = student.HomeTown;
                        ifExists = true;
                    }
                }
                if (!ifExists)
                {
                    students.Add(student);
                }
                }
            string cityName = Console.ReadLine();
            foreach (var student in students)
            {
                if (student.HomeTown == cityName)
                {
                    Console.WriteLine($"{student.Name} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
    class Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

       public Student(string name,string lastName,int age,string homeTown)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Age = age;
            this.HomeTown = homeTown;
        }
    }
}
