using Microsoft.CodeAnalysis.CSharp.Syntax;
using SULS.Services;
using SULS.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }
        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var model = new ProblemSubmitModel
            {
                Name = problemsService.getNameById(id),
                ProblemId = id,
            };

            return this.View(model);
        }

        [HttpPost("/Submissions/Create")]
        public HttpResponse Create(string code, string problemId)
        {
            if (code.Length < 0 || code.Length > 300)
            {
                return this.Error("Text should be between 0 - 300 symbols!");
            }
            submissionsService.Create(problemId, this.GetUserId(), code);

            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            submissionsService.Delete(id);
            return this.Redirect("/");
        }
    }
}
