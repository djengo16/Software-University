using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class CardsController : Controller
    {
        public HttpResponse Add(HttpRequest request)
        {
            return this.View("Views/Cards/Add.cshtml");
        }

        public HttpResponse All(HttpRequest request)
        {
            return this.View("Views/Cards/All.cshtml");
        }

        public HttpResponse Collection(HttpRequest request)
        {
            return this.View("Views/Cards/Collection.cshtml");
        }
    }
}
