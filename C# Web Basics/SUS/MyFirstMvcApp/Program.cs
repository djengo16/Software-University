using MyFirstMvcApp.Controllers;
using SUS.HTTP;

using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var server = new HttpServer();
            
            server.AddRoute("/", new HomeController().Index);
            server.AddRoute("/favicon.ico", new StaticFilesController().Favicon);
            server.AddRoute("/about", new HomeController().Index);
            server.AddRoute("/users/login", new UsersController().Login);
            server.AddRoute("/users/register",new UsersController().Register);
            server.AddRoute("/cards/all", new CardsController().All);
            server.AddRoute("/cards/add", new CardsController().Add);
            server.AddRoute("/cards/collection", new CardsController().Collection);
            
            await server.StartAsync(80);
        }



        



       
    }
}
