using System;
using System.Linq;

namespace Array___Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArrays = Console.ReadLine().Split().ToArray();
            int rotationSize = int.Parse(Console.ReadLine());
            
            for (int rotation = 0; rotation < rotationSize; rotation++)
            {
              
                var first = inputArrays[0];
                for (int i = 0; i < inputArrays.Length-1; i++)
                {
                    inputArrays[i] = inputArrays[i + 1];
                }
                inputArrays[inputArrays.Length - 1] = first;
            }
            var result = String.Join(" ", inputArrays);
            Console.WriteLine(result);
        }
    }
}
