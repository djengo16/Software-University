using Microsoft.EntityFrameworkCore;
using MUSACA.Data;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA
{
    class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
           //throw new NotImplementedException();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            new ApplicationDbContext().Database.Migrate();
        }
    }
}
