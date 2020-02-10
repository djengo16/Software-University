using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());

            var bulletsArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var locksArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> bullets = new Stack<int>(bulletsArr);
            Queue<int> locks = new Queue<int>(locksArr);
            int startBulletsCount = bullets.Count();
            int valueOfIntelligence = int.Parse(Console.ReadLine());
            int counter = 0;
            while (locks.Count != 0)
            {
                if (bullets.Pop() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if(bullets.Count == 0 && locks.Count != 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count()}");
                    return;
                }
                counter++;
                if (counter % gunBarrel == 0 && bullets.Count != 0 )
                {
                    Console.WriteLine("Reloading!");
                }                        
            }
            int earned = valueOfIntelligence - ((startBulletsCount - bullets.Count) * bulletPrice);
            Console.WriteLine($"{bullets.Count()} bullets left. Earned ${earned}");
        }
    }
}
