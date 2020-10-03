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

            List<Route> routeTable = new List<Route>();
           
            routeTable.Add(new Route("/", new HomeController().Index));
            routeTable.Add(new Route("/favicon.ico", new StaticFilesController().Favicon));
            routeTable.Add(new Route("/about", new HomeController().Index));
            routeTable.Add(new Route("/users/login", new UsersController().Login));
            routeTable.Add(new Route("/users/register",new UsersController().Register));
            routeTable.Add(new Route("/cards/all", new CardsController().All));
            routeTable.Add(new Route("/cards/add", new CardsController().Add));
            routeTable.Add(new Route("/cards/collection", new CardsController().Collection));


            await Host.RunAsyc(routeTable, 80);
        }



        



       
    }
}
