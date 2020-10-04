using SUS.HTTP;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    public static class Host
    {
        public static async Task CreateHostAsync(IMvcApplication application,int port)
        {
            List<Route> routeTable = new List<Route>();
            application.ConfigureServices();
            application.Configure(routeTable);

            var server = new HttpServer(routeTable);            

            await server.StartAsync(port);
        }
    }
}