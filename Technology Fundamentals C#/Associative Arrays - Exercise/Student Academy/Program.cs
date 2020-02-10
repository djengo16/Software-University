using System;
using System.Linq;
using System.Collections.Generic;

namespace Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string currentStudent = Console.ReadLine();
                double currentGrade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(currentStudent))
                {
                    students.Add(currentStudent, new List<double>());
                }
                students[currentStudent].Add(currentGrade);
            }
            students = students.Where(x => x.Value.Average() >= 4.50)
                .OrderByDescending(x => x.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():F2}");
            }
        }
    }
}
