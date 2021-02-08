using SULS.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService serivece;

        public ProblemsController(IProblemsService serivece)
        {
            this.serivece = serivece;
        }
        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost("/Problems/Create")]
        public HttpResponse Create(string name,int points)
        {
            if(string.IsNullOrWhiteSpace(name) || name.Length < 5 || name.Length > 20)
            {
                return this.Error("Name should be between 5 and 20 symbols!");
            }

            if(points < 50 || points > 300)
            {
                return this.Error("Points should be between 50 and 300");
            }

            serivece.Create(name, points);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            var model = serivece.GetProblemDetails(id);

            return this.View(model);
        }
    }
}
