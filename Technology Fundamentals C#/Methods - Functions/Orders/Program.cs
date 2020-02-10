using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double price = Order(product, quantity);
            Console.WriteLine($"{price:F2}");
        }
        
        static double Order(string product, int quantity)
        {
            double price = 0;
            switch (product)
            {
                case "coffee":
                    price = 1.50;
                        break;
                case "water":
                    price = 1;
                    break;
                case "coke":
                    price = 1.40;
                    break;
                case "snacks":
                    price = 2;
                    break;
            }
            price = (quantity * price);
            return price;
        }
    }
}
