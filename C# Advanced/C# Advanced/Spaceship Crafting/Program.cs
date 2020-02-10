using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Spaceship_Crafting
{
    class Program
    {
        static void Main(string[] args)
        {

            //First, you will be given a sequence of integers, representing chemical liquids. 
            //    Afterwards, you will be given another sequence of integers representing physical items.

            //You need to start from the first liquid and try to mix it with the last physical item.
            //    If the sum of their values is equal to any of the items in the table below – create the item
            //    corresponding to the value and remove both the liquid and the physical item. Otherwise, 
            //remove only the liquid and increase the value of the item by 3.
            //    You need to stop combining when you have no more liquids or physical items.

            var firstInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> chemicalLiquids = new Queue<int>(firstInput);
            Stack<int> physicalItem = new Stack<int>(secondInput);

            Dictionary<string, int> items = new Dictionary<string, int>();
            items.Add("Glass", 0);
            items.Add("Aluminium", 0);
            items.Add("Lithium", 0);
            items.Add("Carbon fiber", 0);
            while (chemicalLiquids.Any() && physicalItem.Any())
            {
                int currentSum = chemicalLiquids.Dequeue() + physicalItem.Peek();

                switch(currentSum)
                {
                    case 25:

                        physicalItem.Pop();
                        items["Glass"]++;
                        break;
                    case 50:

                        physicalItem.Pop();
                        items["Aluminium"]++;
                        break;
                    case 75:

                        physicalItem.Pop();
                        items["Lithium"]++;
                        break;
                    case 100:

                        physicalItem.Pop();
                        items["Carbon fiber"]++;
                        break;
                    default:
                        physicalItem.Push(physicalItem.Pop() + 3);
                        break;

                }
            }

            bool ifSucceeded = true;

            foreach (var item in items)
            {
                if (item.Value == 0)
                {
                   ifSucceeded = false;
                }
            }

            if (ifSucceeded)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (chemicalLiquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",chemicalLiquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }
            if (physicalItem.Any())
            {
                Console.WriteLine($"Physical items left: {string.Join(", ",physicalItem)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

           

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Aluminium: {items["Aluminium"]}");
            sb.AppendLine($"Carbon fiber: {items["Carbon fiber"]}");
            sb.AppendLine($"Glass: {items["Glass"]}");
            sb.AppendLine($"Lithium: {items["Lithium"]}");


            Console.WriteLine(sb.ToString().TrimEnd());
            
        }
    }
}
