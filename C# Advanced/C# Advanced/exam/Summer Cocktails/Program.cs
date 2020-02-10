using System;
using System.Collections.Generic;
using System.Linq;

namespace Summer_Cocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> coctails = new Dictionary<string, int>();

            int[] inputQueue = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> ingredients = new Queue<int>(inputQueue);

            int[] inputStack = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> freshnesLevel = new Stack<int>(inputStack);

            CocktailCheck(coctails, ingredients, freshnesLevel);

            if (coctails.Count == 4)  Console.WriteLine("It's party time! The cocktails are ready!"); 
            else Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }
            if (coctails.Any())
            {
                var result = coctails.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);


                foreach (var item in result)
                {
                    Console.WriteLine($"# {item.Key} --> {item.Value}");
                }
            }
        }

        private static void CocktailCheck(Dictionary<string, int> coctails, Queue<int> ingredients, Stack<int> freshnesLevel)
        {
            while(ingredients.Count != 0 && freshnesLevel.Count != 0)
            {

                while(ingredients.Any() && ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                }

                int totalFreshnesLevel = ingredients.Peek() * freshnesLevel.Pop();

                switch (totalFreshnesLevel)
                {
                    case 150:
                        if (!coctails.ContainsKey("Mimosa"))
                        {
                            coctails.Add("Mimosa", 0);
                        }
                        coctails["Mimosa"]++;
                        ingredients.Dequeue();
                        break;
                    case 250:
                        if (!coctails.ContainsKey("Daiquiri"))
                        {
                            coctails.Add("Daiquiri", 0);
                        }
                        coctails["Daiquiri"]++;
                        ingredients.Dequeue();
                        break;
                    case 300:
                        if (!coctails.ContainsKey("Sunshine"))
                        {
                            coctails.Add("Sunshine", 0);
                        }
                        coctails["Sunshine"]++;
                        ingredients.Dequeue();
                        break;
                    case 400:
                        if (!coctails.ContainsKey("Mojito"))
                        {
                            coctails.Add("Mojito", 0);
                        }
                        coctails["Mojito"]++;
                        ingredients.Dequeue();
                        break;

                    default:
                        ingredients.Enqueue(ingredients.Dequeue() + 5);
                        break;
                }
            }
        }
    }
}
