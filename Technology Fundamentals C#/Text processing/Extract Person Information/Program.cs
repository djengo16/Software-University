using System;
using System.Linq;
using System.Text;
namespace Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string name = string.Empty;
                int age = 0;
                for (int j = 0; j < input.Length; j++)
                {
                    string current = input[j];

                    if (current[0] == '@' && current[current.Length-1] == '|' || current[current.Length-1] == '@' && current[0] == '|')
                    {
                        name = current.Substring(1, current.Length - 2);
                    }
                    if (current[0] == '#' && current[current.Length-1] == '*' || current[current.Length-1] == '#' && current[0] == '*')
                    {
                        age = int.Parse(current.Substring(1, current.Length - 2));
                    }
                }
                if (name != string.Empty && age != 0)
                {
                    Console.WriteLine($"{name} is {age} years old.");
                }
            }
        }
    }
}
