using System;
using System.Collections.Generic;
using System.Linq;

namespace Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string command = string.Empty;

            while((command = Console.ReadLine()) != "end")
            {
                string[] currentBox = command.Split(" ").ToArray();

                Box box = new Box();
                box.Item = new Item();
                box.SerialNumber = int.Parse(currentBox[0]);
                box.Item.Name = currentBox[1];
                box.Quantity = int.Parse(currentBox[2]);
                box.PriceBox = int.Parse(currentBox[2]) * double.Parse(currentBox[3]);
                box.Item.Price =  double.Parse(currentBox[3]);
                boxes.Add(box);
                
                
            }

            List<Box> boxesDescending = new List<Box>();  
            while(boxes.Count > 0)
            {
                double biggestPrice = -1;
                int biggestIndex = -1;
                for (int i = 0; i < boxes.Count;i++)
                {
                    if (boxes[i].PriceBox > biggestPrice)
                    {
                        biggestPrice = boxes[i].PriceBox;
                        biggestIndex = i;
                    }
                }
                boxesDescending.Add(boxes[biggestIndex]);
                boxes.RemoveAt(biggestIndex);
            }
            
            foreach (var box in boxesDescending)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.PriceBox:F2}");
            }
            
        }
    }
    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public double PriceBox { get; set; }

    }
    class Item
    {
         public string Name { get; set; }
        public double Price { get; set; }
    }
}
