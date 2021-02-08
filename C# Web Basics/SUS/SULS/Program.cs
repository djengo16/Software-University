using SUS.MvcFramework;
using System;

namespace SULS
{
    public class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            await Host.CreateHostAsync(new Startup(), 80);
        }
    }
}
