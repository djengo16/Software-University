using System;
using System.Collections.Generic;
using System.Linq;

namespace Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> plannedGifts = Console.ReadLine().Split().ToList();

            string command = string.Empty;

            while ((command=Console.ReadLine()) != "No Money")
            {
                string[] toDo = command.Split(" ").ToArray();

                switch (toDo[0])
                {
                    case "OutOfStock":
                        while (plannedGifts.Contains(toDo[1]))
                        {
                            plannedGifts[plannedGifts.IndexOf(toDo[1])] = "None";
                        }
                        break;
                    case "Required":
                        int index = int.Parse(toDo[2]);
                        string item = toDo[1];
                        if (index > 0 && index < plannedGifts.Count)
                        {
                            plannedGifts.Insert(index, item);
                            plannedGifts.RemoveAt(index + 1);
                        }                        
                        break;
                    case "JustInCase":
                        plannedGifts.RemoveAt(plannedGifts.Count - 1);
                        plannedGifts.Add(toDo[1]);
                        break;
                }
            }
            List<string> finalGifts = new List<string>();

            for (int i = 0; i < plannedGifts.Count; i++)
            {
                if (plannedGifts[i] != "None")
                {
                    finalGifts.Add(plannedGifts[i]);
                }
            }
            Console.WriteLine(String.Join(" ", finalGifts));
        }
        
    }
}
