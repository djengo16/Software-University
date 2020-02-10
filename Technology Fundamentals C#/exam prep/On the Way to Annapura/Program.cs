using System;
using System.Collections.Generic;
using System.Linq;
namespace On_the_Way_to_Annapura
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, List<string>> stores = new Dictionary<string, List<string>>();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputAsArr = input.Split("->").ToArray();
                string option = inputAsArr[0];
                if (option == "Add")
                {
                    if (!inputAsArr[2].Contains(","))
                    {
                        FirtTypeAdd(inputAsArr, stores);
                    }
                    else
                    {
                        SecondTypeAdd(inputAsArr, stores);
                    }
                }
                else if (option == "Remove")
                {
                    if (stores.ContainsKey(inputAsArr[1]))
                    {
                        stores.Remove(inputAsArr[1]);
                    }
                }
            }
            stores = stores
                    .OrderByDescending(x => x.Value.Count)
                    .ThenByDescending(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Stores list:");
            foreach (var store in stores)
            {
                Console.WriteLine(store.Key);
                foreach (var item in store.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }

        }

        private static void SecondTypeAdd(string[] inputAsArr, Dictionary<string, List<string>> stores)
        {
            string[] items = inputAsArr[2].Split(",").ToArray();
            string storeName = inputAsArr[1];
            if (!stores.ContainsKey(storeName))
            {
                stores.Add(storeName, new List<string>());
            }
            stores[storeName].AddRange(items);

        }

        private static void FirtTypeAdd(string[] inputAsArr, Dictionary<string, List<string>> stores)
        {
            string storeName = inputAsArr[1];
            string item = inputAsArr[2];
            if (!stores.ContainsKey(storeName))
            {
                stores.Add(storeName, new List<string>());
            }
            stores[storeName].Add(item);
        }
    }
}
