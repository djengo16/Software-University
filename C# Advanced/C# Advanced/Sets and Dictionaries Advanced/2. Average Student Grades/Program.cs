using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> grades = new Dictionary<string, List<double>>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();
                string name = input[0];
                double currentGrade = double.Parse(input[1]);

                if (!grades.ContainsKey(name))
                {
                    grades.Add(name, new List<double>());
                }
                grades[name].Add(currentGrade);
            }
            foreach (var current in grades)
            {
                Console.WriteLine($"{current.Key} -> {string.Join(" ",current.Value.Select(x=>x.ToString("F2")))} (avg: {current.Value.Average():F2})");
            }
        }
    }
}
