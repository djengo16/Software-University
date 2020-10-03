using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    public static class Host
    {
        public static async Task RunAsyc(List<Route> routeTable)
        {
            var server = new HttpServer();
            await server.StartAsync(80);
        }
    }
}