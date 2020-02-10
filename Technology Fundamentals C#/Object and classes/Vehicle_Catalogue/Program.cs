using System;
using System.Collections.Generic;
using System.Linq;
namespace Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Catalogue catalogue;
            while((command = Console.ReadLine())!= "end")
            {
                string[] currentVehicle = command.Split("/").ToArray();
                if(currentVehicle[0] == "Car")
                {
                    Car car = new Car(currentVehicle[1], currentVehicle[2], int.Parse(currentVehicle[3]));
                                        
                }
                else
                {
                    Truck truck = new Truck(currentVehicle[1], currentVehicle[2], double.Parse(currentVehicle[3]));
                }
                
            }
        }
    }
    class Truck
    {
       public Truck(string brand,string model,double weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }
    class Car
    {
       public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    class Catalogue
    {
        public Catalogue()
        {
            Cars =  new Car();
            Trucks = new Truck();
        }
 
        public List<Car> Cars{ get; set;}
        public List<Truck> Trucks{ get; set;}
        
    }
}
