using System;

namespace trys
{

    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            string finalResult = string.Empty;

            for (int i = 0; i < counter; i++)
            {
                string number = (Console.ReadLine());
                if (number == "0")
                {
                    finalResult += " ";
                }
                else
                {
                    int numberOfdigits = number.Length;
                    int mainDigit = number[0]- '0';
                    int offset = (mainDigit - 2) * 3;
                    if (mainDigit == 8 || mainDigit == 9)
                    {
                        offset++;
                    }
                    int letterIndex = offset + number.Length - 1; //(offset + digit length - 1).
                    finalResult += (char)(97 + letterIndex);
                }
           }
            Console.WriteLine(finalResult);
        }
    }
}

