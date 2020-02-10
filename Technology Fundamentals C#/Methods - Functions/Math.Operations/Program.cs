using System;

namespace Math.Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            
            double result = MathOperation(numOne,numTwo,operation);
            Console.WriteLine(result);
        }

        static double MathOperation(int numOne,int numTwo,char operation)
        {
            double result=0;

            switch (operation)
            {
                case '*':
                    result = numOne * numTwo;
                    break;

                case '-':
                    result = numOne - numTwo;
                    break;

                case '/':
                    result = numOne / numTwo;
                    break;

                case '+':
                    result = numOne + numTwo;
                    break;
            }


            return result;
        }
    }
}
