using SUS.MvcFramework;
using System;
using System.Threading.Tasks;

namespace SharedTrip
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new Startup(), 80);
        }
    }
}
