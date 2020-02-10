using System;
using System.Linq;
namespace Valid_username
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] users = Console.ReadLine().Split(", ").ToArray();

            foreach (var user in users)
            {
                string current = user;
                bool check = true;
                
                if (user.Length >= 3 && user.Length <= 16)
                {
                    
                    for (int i = 0; i < user.Length; i++)
                    {

                        if (!Char.IsLetterOrDigit(current[i]) && current[i] != '-' && current[i] != '_') check = false;
                                              
                    }
                    if (check)
                        Console.WriteLine(current);
                }
               
            }
        }
    }
}
