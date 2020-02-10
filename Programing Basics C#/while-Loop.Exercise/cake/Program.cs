using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int pieces = width * length;
            int piecesWeWant = 0;
            int piece = 0;
            
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "STOP")
                {
                    int left = pieces - piecesWeWant;
                    Console.WriteLine($"{left} pieces are left.");
                    break;
                }
                else if (input != "STOP")
                {
                    piece = int.Parse(input);
                    piecesWeWant += piece;
                    if (piecesWeWant > pieces)
                    {
                        int needed = piecesWeWant - pieces;
                        Console.WriteLine($"No more cake left! You need {needed} pieces more");
                        break;
                    }
                }
                
            }
        }
    }
}
