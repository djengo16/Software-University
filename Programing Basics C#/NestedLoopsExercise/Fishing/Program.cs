using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int fishCount = int.Parse(Console.ReadLine());
            string fish = Console.ReadLine();
            int counter = 0;
            double earned = 0; double lost = 0;
            while (fish != "Stop")
            {
                double sum = 0;
                double FishKg = double.Parse(Console.ReadLine());
                for (int i = 0; i < fish.Length; i++)
                {
                    sum += fish[i];
                }
                sum /= FishKg;
                counter++;
                if (counter % 3 == 0)
                {
                    earned += sum;
                }
                else
                {
                    lost += sum;
                }
                if (counter == fishCount)
                {
                    Console.WriteLine("Lyubo fulfilled the quota!");
                    break;
                }
                fish = Console.ReadLine();
            }
            if (earned > lost)
            {
                double won = earned - lost;
                Console.WriteLine($"Lyubo's profit from {counter} fishes is {won:F2} leva.");
            }
            else
            {
                double lostmoney = lost - earned;
                Console.WriteLine($"Lyubo lost {lostmoney:F2} leva today.");
            }
        }
    }
}
