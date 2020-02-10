namespace WildFarm
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;


            List<Animal> animals = new List<Animal>();

            while((command = Console.ReadLine()) != "End")
            {

                    var information = command.Split().ToArray();
                    string type = information[0];
                string name = information[1];
                double weight = double.Parse(information[2]);
                    switch (type)
                    {
                        case "Hen":                        
                        case "Owl":
                        
                        double wingSize = double.Parse(information[3]);
                        if(type == "Hen")
                        {
                            Hen hen = new Hen(name, weight, wingSize);
                            animals.Add(hen);
                        }
                        else
                        {
                            Owl owl = new Owl(name, weight, wingSize);
                            animals.Add(owl);
                        }                        
                        
                            break;
                    case "Cat":
                    case "Tiger":
                        
                        string livingRegionFeline = information[3];
                        string breed = information[4];
                        if (type == "Tiger")
                        {
                            Tiger tiger = new Tiger(name, weight, livingRegionFeline, breed);
                            animals.Add(tiger);
                        }
                        else
                        {
                            Cat cat = new Cat(name, weight, livingRegionFeline, breed);
                            animals.Add(cat);
                        }
                        //Tiger Typcho 167.7 Asia Bengal
                        break;
                    //Mouse Jerry 0.5 Anywhere
                    case "Dog":
                    case "Mouse":
                        string livingRegion = information[3];
                        if (type == "Dog")
                        {
                            Dog dog = new Dog(name, weight, livingRegion);
                            animals.Add(dog);
                        }
                        else
                        {
                            Mouse mouse = new Mouse(name, weight, livingRegion);
                        }
                        break;
                    }

                var foodArgs = Console.ReadLine().Split();
                string foodType = foodArgs[0];
                int quantity = int.Parse(foodArgs[1]);

                Food food = FoodFactory.CreateFood(foodType, quantity);

                animals[animals.Count - 1].ProduceSound();
                animals[animals.Count - 1].Eat(food);
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
