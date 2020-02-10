using System;

namespace The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int countOfPlayers = int.Parse(Console.ReadLine());

            double groupEnergy = double.Parse(Console.ReadLine());

            double waterPerPerson = double.Parse(Console.ReadLine());
            double foodPerPerson = double.Parse(Console.ReadLine());

            double totalWater = (countOfPlayers * waterPerPerson) * days;
            double totalFood = (countOfPlayers * foodPerPerson) * days;

            int dayCounter = 0;

            while (groupEnergy > 0)
            {
                double losedEnergyForTheDay = double.Parse(Console.ReadLine());
                
                
                
                    groupEnergy -= losedEnergyForTheDay;
                if (groupEnergy <= 0)
                {
                    break;
                }
                dayCounter++;
                if (dayCounter % 2 == 0)
                {
                    double energyFromWater = groupEnergy * 0.05;
                    groupEnergy += energyFromWater;
                    totalWater -= totalWater * 0.3;
                }
                if (dayCounter % 3 == 0)
                {
                    totalFood -= (totalFood /countOfPlayers);
                    groupEnergy += (groupEnergy * 0.10);
                }
                if (dayCounter == days)
                {
                    break;
                }
            }
            if (dayCounter == days)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:F2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totalFood:F2} food and {totalWater:F2} water.");
            }
            
        }
    }
}
