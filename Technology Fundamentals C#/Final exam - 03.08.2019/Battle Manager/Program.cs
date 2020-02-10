using System;
using System.Linq;
using System.Collections.Generic;


namespace Battle_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> people = new Dictionary<string, int[]>();

            string command = string.Empty;

            while ((command=Console.ReadLine()) != "Results")
            {
                string[] options = command.Split(":").ToArray();
                string option = options[0];


                if (option == "Add")
                {
                    string name = options[1];
                    int health = int.Parse(options[2]);
                    int energy = int.Parse(options[3]);
                    if (!people.ContainsKey(name))
                    {
                        people.Add(name, new int[2]);
                        people[name][1] += energy;
                    }
                    people[name][0] += health;
                    
                }
                else if (option == "Attack")
                {
                    
                    string attackerName = options[1];
                    string defenderName = options[2];
                    int damage = int.Parse(options[3]);

                    if (people.ContainsKey(attackerName) && people.ContainsKey(defenderName))
                    {
                        people[defenderName][0] -= damage;
                        people[attackerName][1]--;
                        if (people[defenderName][0] <= 0)
                        {
                            Console.WriteLine($"{defenderName} was disqualified!");
                            people.Remove(defenderName);
                        }
                        if (people[attackerName][1] <= 0)
                        {
                            Console.WriteLine($"{attackerName} was disqualified!");
                            people.Remove(attackerName);
                        }
                    }
                }
                else if (option == "Delete")
                {
                    string username = options[1];

                    if (username == "All")
                    {
                        people.Clear();
                    }
                    else if (people.ContainsKey(username))
                    {
                        people.Remove(username);
                    }
                }
                
            }
            Console.WriteLine($"People count: {people.Count}");
            people = people.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var current in people)
            {
                Console.WriteLine($"{current.Key} - {current.Value[0]} - {current.Value[1]}");
            }
        }
    }
}
