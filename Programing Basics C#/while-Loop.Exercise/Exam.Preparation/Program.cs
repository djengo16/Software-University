using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int badGrades = int.Parse(Console.ReadLine());
            string LastProblem = string.Empty;
            int counterProblems = 0;
            double totalGrade = 0;
            int badgradesCounter = 0;
            while (true)
            {
                string exerciseName = Console.ReadLine();                                                                             
                double averageGrade = totalGrade / counterProblems;
                

                if (exerciseName != "Enough")
                {
                    
                    counterProblems++;

                    double grade = double.Parse(Console.ReadLine());
                    totalGrade = totalGrade + grade;
                    LastProblem = exerciseName;
                    if (grade <= 4)
                    {
                        badgradesCounter++;
                    }
                    if (badgradesCounter == badGrades)
                    {
                        Console.WriteLine($"You need a break, {badgradesCounter} poor grades.");
                        break;
                    }
                }
                               
                else if (exerciseName == "Enough")
                {
                    Console.WriteLine($"Average score: {averageGrade:F2}");
                    Console.WriteLine($"Number of problems: {counterProblems}");
                    Console.WriteLine($"Last problem: {LastProblem}");
                    break;
                }
                
            }
            
        }
    }
}
