using System;
using System.Linq;
using System.Collections.Generic;

namespace Company_User
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] current = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string company = current[0];
                string id = current[1];

                if (companies.ContainsKey(company))
                {
                    if (!companies[company].Contains(id))
                    {
                        companies[company].Add(id);
                    }
                }
                else
                {
                    companies.Add(company, new List<string>());
                    companies[company].Add(id);
                }
            }
            foreach (var company in companies.OrderBy(x=>x.Key))
            {
                Console.WriteLine(company.Key);
                foreach (var current in company.Value)
                {
                    Console.WriteLine($"-- {current}");
                }
            }
        }
    }
}
