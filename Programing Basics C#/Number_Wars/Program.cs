using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPlayer = Console.ReadLine();
            string secondPlayer = Console.ReadLine();

            int firstPlayerPoints = 0;
            int secondPlayerPoints = 0;

            string command = Console.ReadLine();
            while (command != "End of game")
            {
                int firstNum = int.Parse(command);
                int secondNum = int.Parse(Console.ReadLine());

                if (firstNum > secondNum) firstPlayerPoints += (firstNum - secondNum);
                else if (secondNum > firstNum) secondPlayerPoints += (secondNum - firstNum);
                else if (firstNum == secondNum)
                {
                    Console.WriteLine("Number wars!");
                    int first = int.Parse(Console.ReadLine());
                    int second = int.Parse(Console.ReadLine());

                    if (first > second) Console.WriteLine($"{firstPlayer} is winner with {firstPlayerPoints} points");
                    if (first < second) Console.WriteLine($"{secondPlayer} is winner with {secondPlayerPoints} points");
                    break;
                }
                command = Console.ReadLine();
                if (command == "End of game")
                {
                    Console.WriteLine($"{firstPlayer} has {firstPlayerPoints} points");
                    Console.WriteLine($"{secondPlayer} has {secondPlayerPoints} points");
                    break;
                }
            }
        }
    }
}
