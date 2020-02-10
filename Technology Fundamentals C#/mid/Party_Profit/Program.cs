using System;

namespace Party_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int companions = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int coins = 0;

            for (int i = 1; i <= days; i++)
            {
                
                if (i % 10 == 0)
                {
                    companions -= 2;
                }
                if (i % 15 == 0)
                {

                    companions += 5;
                    coins -= companions * 2;
                }
                if (i % 3 == 0)
                {
                    coins -= companions * 3;
                }
                 if (i % 5 == 0)
                {
                    coins += companions * 20;
                }
                

                coins += 50;
                coins -= companions * 2;
            }
                int each = (coins / companions);
                Console.WriteLine($"{companions} companions received {each} coins each.");
            }
        }
    }

