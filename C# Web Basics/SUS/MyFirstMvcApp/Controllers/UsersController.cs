using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return this.View();            
        }
        public HttpResponse Register(HttpRequest request)
        {
           return this.View();

        }
        public HttpResponse DoLogin(HttpRequest request)
        {
            return this.Redirect("/");

        }
    }
}
