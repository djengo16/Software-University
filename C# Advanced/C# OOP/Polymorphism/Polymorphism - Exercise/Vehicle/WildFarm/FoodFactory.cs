using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public static class FoodFactory
    {
        public static Food CreateFood(string type,int quantity)
        {
            string foodType = type.ToLower();

            switch (foodType)
            {
                case "vegetable":
                    return new Vegetable(quantity);
                    break;
                case "fruit":
                    return new Fruit(quantity);
                        break;
                case "meat":
                    return new Meat(quantity);
                    break;
                case "seeds":
                    return new Seeds(quantity);
                    break;
                default:
                    throw new ArgumentException("Invalid food type!");
                        break;
            }
        }
    }
}
