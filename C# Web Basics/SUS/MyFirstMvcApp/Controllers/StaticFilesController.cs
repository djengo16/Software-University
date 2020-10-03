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
            var fileBytes = File.ReadAllBytes("../../../wwwroot/favicon.ico");
            var response = new HttpResponse("image/x-icon", fileBytes);
            return response;
        }
    }
}
