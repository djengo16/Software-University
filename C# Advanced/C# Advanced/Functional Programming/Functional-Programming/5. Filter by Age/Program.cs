using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(", ");
                string name = input[0];
                int age = int.Parse(input[1]);

                Person current = new Person(name, age);
                people.Add(current);
            }
            string condition = Console.ReadLine();
            int conditionAge = int.Parse(Console.ReadLine());
            var type = Console.ReadLine().Split();
                    
            //Last => \/
            Print(condition, people, conditionAge, type);

        }

        private static void Print(string condition, List<Person> people, int conditionAge, string[] type)
        {
            Func<Person, bool> predicate;
            switch (condition)
            {
                case "younger":
                    predicate = x => x.Age < conditionAge;
                    break;
                case "older":
                    predicate = x => x.Age >= conditionAge;
                    break;
                default:
                    predicate = null;
                    break;
            }
            people = people.Where(predicate).ToList();
            foreach (var person in people)
            {
                if (type.Length == 1)
                {
                    Console.WriteLine(person.Name);
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
