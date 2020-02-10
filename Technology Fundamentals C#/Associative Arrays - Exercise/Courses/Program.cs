using System;
using System.Linq;
using System.Collections.Generic;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> students = new Dictionary<string, List<string>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] command1 = command.Split(" : ").ToArray();
                string course = command1[0];
                string student = command1[1];

                if (!students.ContainsKey(course))
                {
                    students.Add(course, new List<string>());
                }
                students[course].Add(student);
            }
           students = students
          .OrderByDescending(x => x.Value.Count)
          .ToDictionary(x => x.Key, x => x.Value);
            foreach (var name in students.Values)
            {
                name.Sort();
            }
            foreach (var current in students)
            {
                Console.WriteLine($"{current.Key}: {current.Value.Count()}");
                foreach (var student in current.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
