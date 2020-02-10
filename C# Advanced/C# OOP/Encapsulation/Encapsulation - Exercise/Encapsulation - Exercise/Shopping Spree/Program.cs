using System;
using System.Collections.Generic;
using System.Linq;
namespace Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create two classes: class Person and class Product. Each person should have a name, 
            //money and a bag of products.Each product should have a name and a cost.
            //Name cannot be an empty string. Money cannot be a negative number.

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            var personInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < personInput.Length; i++)
            {
                var currentPerson = personInput[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = currentPerson[0];
                double money = double.Parse(currentPerson[1]);
                try
                {
                    Person person = new Person(name, money);
                    people.Add(person);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
               
            }

            var productInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productInput.Length; i++)
            {
                var currentProduct = productInput[i].Split("=",StringSplitOptions.RemoveEmptyEntries);
                string name = currentProduct[0];
                double cost = double.Parse(currentProduct[1]);

                try
                {
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }


            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                var input = command.Split();
                string personName = input[0];
                string productName = input[1];

                Person targetPerson = people.FirstOrDefault(x => x.Name == personName);
                Product targetProduct = products.FirstOrDefault(x => x.Name == productName);
                targetPerson.AddToBag(targetProduct);
            }

            foreach (var person in people)
            {
                if (person.Bag.Any())
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag.Select(x => x.Name))}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }
}
