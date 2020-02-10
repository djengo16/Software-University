using System;
using System.Collections.Generic;
using System.Linq;


namespace Softuni_Course_planning
{
    class Program
    {
        static void Main(string[] args)
        {
            var lessons = Console.ReadLine().Split(", ").ToList();
            string command = Console.ReadLine();

            while (command != "course start")
            {
                string[] lessonsCommand = command.Split(":").ToArray();
                switch (lessonsCommand[0])
                {
                    case "Add":
                        AddSubject(lessonsCommand,lessons);
                        break;
                    case "Insert":
                        InsertSubject(lessons, lessonsCommand);
                        break;
                    case "Remove":
                        RemoveSubject(lessons, lessonsCommand);
                        break;
                    case "Swap":
                        SwapSubjects(lessons, lessonsCommand);
                        break;
                    case "Exercise":
                        AddExercise(lessons, lessonsCommand);
                            break;

                }
                command = Console.ReadLine();
  
            }
            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{1 + i}.{lessons[i]}");
            }
        }

        private static void AddExercise(List<string> lessons, string[] lessonsCommand)
        {
            if (!lessons.Contains(lessonsCommand[1]))
            {
                lessons.Add(lessonsCommand[1]);
                lessons.Add($"{lessonsCommand[1]}-Exercise");
            }
            else
            {
                if (lessons.Contains(lessonsCommand[1]))
                {
                    int index = lessons.IndexOf(lessonsCommand[1]) + 1;
                    lessons.Insert(index, $"{lessonsCommand[1]}-Exercise");
                }
            }
        }

        private static void SwapSubjects(List<string> lessons, string[] lessonsCommand)
        {
            if (lessons.Contains(lessonsCommand[1]) && lessons.Contains(lessonsCommand[2]))
            {
                string firstToSwap = lessonsCommand[1];
                string secondToSwap = lessonsCommand[2];
                lessons[lessons.IndexOf(lessonsCommand[2])] = firstToSwap;
                lessons[lessons.IndexOf(lessonsCommand[1])] = secondToSwap;

                string exerciseSwap = string.Empty;
                if (lessons.Contains($"{lessonsCommand[1]}-Exercise") )
                {
                    exerciseSwap = $"{lessonsCommand[1]}-Exercise";
                    lessons.RemoveAt(lessons.IndexOf($"{lessonsCommand[1]}-Exercise"));
                    if (lessons.Count - 1 >= lessons.IndexOf(lessonsCommand[1]) + 1)
                    {
                        lessons.Insert(lessons.IndexOf(lessonsCommand[1]) + 1, exerciseSwap);
                    }
                    else
                    {
                        lessons.Add(exerciseSwap);
                    }
                   
                }
                if (lessons.Contains($"{lessonsCommand[2]}-Exercise"))
                {
                    exerciseSwap = $"{lessonsCommand[2]}-Exercise";
                    lessons.RemoveAt(lessons.IndexOf($"{lessonsCommand[2]}-Exercise"));
                    if (lessons.Count - 1 >= lessons.IndexOf(lessonsCommand[1]) + 1)
                    {
                        lessons.Insert(lessons.IndexOf(lessonsCommand[2]) + 1, exerciseSwap);
                    }
                    else
                    {
                        lessons.Add(exerciseSwap);
                    }
                }
            }
            if (lessons.Contains($"{lessonsCommand[1]}-Exercise") && lessons.Contains($"{lessonsCommand[2]}-Exercise"))
            {
                string firtToswap = ($"{lessonsCommand[1]}-Exercise");
                string second = ($"{lessonsCommand[2]}-Exercise");
                lessons[lessons.IndexOf($"{lessonsCommand[1]}-Exercise")] = second;
                lessons[lessons.IndexOf($"{lessonsCommand[2]}-Exercise")] = firtToswap;

            }
        }

        private static void RemoveSubject(List<string> lessons, string[] lessonsCommand)
        {
            if (lessons.Contains(lessonsCommand[1]))
            {
                lessons.Remove(lessonsCommand[1]);
            }
             if (lessons.Contains($"{lessonsCommand[1]}-Exercise"))
            {
                lessons.Remove($"{lessonsCommand[1]}-Exercise");
            }
        }

        private static void InsertSubject(List<string> lessons, string[] lessonsCommand)
        {
            if (!lessons.Contains(lessonsCommand[1]))
            {
                lessons.Insert(int.Parse(lessonsCommand[2]), lessonsCommand[1]);
            }
        }

        private static void AddSubject(string[] lessonsCommand, List<string> lessons)
        {
         if (!lessons.Contains(lessonsCommand[1]))
            {
                lessons.Add(lessonsCommand[1]);
            }
        }
    }
}
