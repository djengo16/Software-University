using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.IO;


namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController : Controller
    {
         public HttpResponse Favicon(HttpRequest request)
        {
            var path ="../../../wwwroot/favicon.ico";
            var contentType ="image/x-icon";
            return this.File(path,contentType);
        }
    }
}
