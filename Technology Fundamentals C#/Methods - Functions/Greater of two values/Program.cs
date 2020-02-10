using System;

namespace Greater_of_two_values
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            switch (command)
            {
                case "int":
                    IntegerValuesCheck();
                    break;
                case "string":
                    StringValuesCheck();
                    break;
                case "char":
                    CharValuesCHeck();
                    break;
            }

        }

        static void IntegerValuesCheck() 
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            if (numOne > numTwo)
            {
                Console.WriteLine(numOne);
            }
            else
            {
                Console.WriteLine(numTwo);
            }
        }

        static void StringValuesCheck()
        {
            string valueOne = Console.ReadLine();
            string valueTwo = Console.ReadLine();
            int sumOne = 0; int sumTwo = 0;
            for (int i = 0; i < valueOne.Length; i++)
            {
                sumOne += valueOne[i];
            }
            for (int i = 0; i < valueTwo.Length; i++)
            {
                sumTwo += valueTwo[i];
            }

            if (sumOne > sumTwo)
            {
                Console.WriteLine(valueOne);
            }
            else
            {
                Console.WriteLine(valueTwo);
            }
        }

        static void CharValuesCHeck()
        {
            char valueOne = char.Parse(Console.ReadLine());
            char valueTwo = char.Parse(Console.ReadLine());

            if (valueOne > valueTwo)
            {
                Console.WriteLine(valueOne);
            }

            else
            {
                Console.WriteLine(valueTwo);
            }
        }
    }
}
