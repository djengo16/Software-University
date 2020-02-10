using System;

namespace Student_information
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            int studentAge = int.Parse(Console.ReadLine());
            float studentGrade = float.Parse(Console.ReadLine());
            Console.WriteLine($"Name: {studentName}, Age: {studentAge}, Grade: {studentGrade}");
        }
    }
}
