using SUS.MvcFramework;
using System;

namespace BattleCardsExam
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            await Host.CreateHostAsync(new Startup(), 80);
        }
    }
}
