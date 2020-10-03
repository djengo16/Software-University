using SUS.HTTP;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    public static class Host
    {
        public static async Task RunAsyc(List<Route> routeTable,int port)
        {
            var server = new HttpServer(routeTable);            

            await server.StartAsync(port);
        }
    }
}