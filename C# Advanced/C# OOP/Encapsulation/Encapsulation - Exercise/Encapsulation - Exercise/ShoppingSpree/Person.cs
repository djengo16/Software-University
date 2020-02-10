using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private List<Product> bagOfProducts;

        private string name;
        private double money;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;

            bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }


        public double Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
            => this.bagOfProducts.AsReadOnly();

        public void AddToBag(Product product)
        {
            if (this.Money - product.Cost >= 0)
            {
                this.bagOfProducts.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");
                this.money -= product.Cost;
            }
            else
            {
                Console.WriteLine($"{this.name} can't afford {product.Name}");
            }
        }

    }
}
