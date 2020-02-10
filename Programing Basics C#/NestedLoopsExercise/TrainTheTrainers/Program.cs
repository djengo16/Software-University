using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int judges = int.Parse(Console.ReadLine());
            string presentation = Console.ReadLine();
            double totalGrade = 0; int counter = 0;
            while (presentation != "Finish")
            {
                double grade = 0; double totalGradePerPresentation = 0;
                for (int i =0; i < judges; i++)
                {
                    grade = double.Parse(Console.ReadLine());
                    totalGradePerPresentation += grade;
                }
                totalGrade += totalGradePerPresentation;
                Console.WriteLine($"{presentation} - {(totalGradePerPresentation / judges):F2}.");
                counter++;
                presentation = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {(totalGrade / (judges * counter)):F2}.");
        }
    }
}
