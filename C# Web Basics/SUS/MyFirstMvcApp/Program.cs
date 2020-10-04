using MyFirstMvcApp.Controllers;

using SUS.HTTP;
using System.Threading.Tasks;
using System.Collections.Generic;
using SUS.MvcFramework;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {

            await Host.CreateHostAsync(new Startup(), 80);
        }
     
    }
}
