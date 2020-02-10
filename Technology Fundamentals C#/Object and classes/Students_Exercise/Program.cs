using System;
using System.Linq;
using System.Collections.Generic;

namespace Students_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] currentStudent = Console.ReadLine().Split().ToArray();
                Student current = new Student(currentStudent[0], currentStudent[1], double.Parse(currentStudent[2]));
                students.Add(current);
            }
            students = students.OrderByDescending(x => x.Grade).ToList();

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{students[i].FirstName} {students[i].LastName}: {students[i].Grade:F2}");
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

       public Student(string firstName, string  lastName,double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

    }
}
