using System;

namespace Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
           double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            int headset = 0;
            int mouse = 0;
            int keyboard = 0;
            int dispay = 0;
            int keyboardCHeck = 0;
            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    headset++;
                }
                if (i % 3 == 0)
                {
                    mouse++;
                }
                if (i % 6 == 0)
                {
                    keyboard++;
                    keyboardCHeck = keyboard;
                }
                if (keyboardCHeck != 0 && keyboardCHeck % 2 == 0)
                {
                    dispay++;
                    keyboardCHeck = 0;
                }
            }
            double total = (headset * headsetPrice) + (mouse * mousePrice) + (keyboard * keyboardPrice) + (dispay * displayPrice);
            Console.WriteLine($"Rage expenses: {total:f2} lv.");
        }
    }
}
