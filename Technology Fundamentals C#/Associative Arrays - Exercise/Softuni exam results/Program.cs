using System;
using System.Collections.Generic;
using System.Linq;
namespace Softuni_exam_results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> studentsAndPoints = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] input = command.Split("-").ToArray();
                if (input.Length == 3)
                {
                    string student = input[0];
                    string language = input[1];
                    int points = int.Parse(input[2]);
                    if (studentsAndPoints.ContainsKey(student) && studentsAndPoints[student] < points)
                    {
                        studentsAndPoints[student] = points;
                    }
                    else if (!studentsAndPoints.ContainsKey(student))
                    {
                        studentsAndPoints.Add(student, points);
                    }
                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }
                    submissions[language]++;
                }
                else
                {
                    string student = input[0];
                    studentsAndPoints.Remove(student);
                }
            }
            studentsAndPoints = studentsAndPoints
                .OrderByDescending(x => x.Value)
                .ThenBy(x=>x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            submissions = submissions
                .OrderByDescending(x=>x.Value).ThenBy(x=>x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");
            foreach (var student in studentsAndPoints)
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var submission in submissions)
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
