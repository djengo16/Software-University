using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace Letters_Changes_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            double final = 0;
            for (int i = 0; i < data.Length; i++)
            {
                string current = data[i];

                char leftLetter = current[0];
                char rightLetter = current[current.Length - 1];

                StringBuilder builder = new StringBuilder();
                for (int j = 1; j < current.Length - 1; j++)
                {
                    builder.Append(current[j]);
                }
                string digits = builder.ToString();
                int number = int.Parse(digits);
                double resultedNum = FirstOperation(leftLetter, rightLetter, number);
                final += resultedNum;
               
            }
            Console.WriteLine($"{final:F2}");
        }

        private static double FirstOperation(char leftLetter, char rightLetter, double number)
        {
            double resultNum = 0;
           
            
            if (char.IsLower(leftLetter) == true)
            {
                
                int letterPosition = leftLetter - 96;
                resultNum = number * letterPosition;
            }
            else
            {
                leftLetter = char.ToLower(leftLetter);
                int letterPosition = leftLetter - 96;
                resultNum = number / letterPosition;
            }
            if (char.IsLower(rightLetter) == true)
            {
               
                int rightPosition = rightLetter - 96;
                resultNum += rightPosition;
            }
            else
            {
               rightLetter = char.ToLower(rightLetter);
                int rightPosition = rightLetter - 96;
                resultNum -= rightPosition;
            }
            return resultNum;
        }
    }
}
