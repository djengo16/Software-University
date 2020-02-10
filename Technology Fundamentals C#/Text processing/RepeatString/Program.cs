using System;
using System.Text;
using System.Linq;
namespace RepeatString

{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            var result = new StringBuilder();

            foreach (var word in input)
            {
                int size = word.Length;
                for (int i = 0; i < size; i++)
                {
                    result.Append(word);
                }

            }
            Console.WriteLine(result);
        }
    }
}
