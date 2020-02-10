using System;
using System.Collections.Generic;
using System.Linq;


namespace Card_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstDeck = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondDeck = Console.ReadLine().Split().Select(int.Parse).ToList();

            

            while (firstDeck.Any() == true && secondDeck.Any() == true)
            {

                if (firstDeck[0] == secondDeck[0])
                {
                    firstDeck.RemoveAt(0);
                    secondDeck.RemoveAt(0);
                }
                else if (firstDeck[0] > secondDeck[0])
                {
                    firstDeck.Add(firstDeck[0]);
                    firstDeck.Add(secondDeck[0]);

                    secondDeck.RemoveAt(0);
                    firstDeck.RemoveAt(0);
                }
                else if (secondDeck[0] > firstDeck[0])
                {
                    secondDeck.Add(secondDeck[0]);
                    secondDeck.Add(firstDeck[0]);

                    secondDeck.RemoveAt(0);
                    firstDeck.RemoveAt(0);
                }
            }

            int sum = 0;


          if (firstDeck.Any() == true)
            {
                for (int i = 0; i < firstDeck.Count; i++)
                {
                    sum += firstDeck[i];
                }
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
          else
            {
                for (int i = 0; i < secondDeck.Count; i++)
                {
                    sum += secondDeck[i];
                }
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
           
        }
    }
}
