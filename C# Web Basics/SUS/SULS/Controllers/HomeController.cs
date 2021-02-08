using SULS.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService service;

        public HomeController(IProblemsService service)
        {
            this.service = service;
        }
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                var viewModel = this.service.GetAllProblemsHomePage();
                
                return this.View(viewModel, "IndexLoggedIn");
            }
            else
            {
                return this.View();
            }


        }
    }
}
