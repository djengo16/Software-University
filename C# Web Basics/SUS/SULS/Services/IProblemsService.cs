using SULS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Services
{
    public interface IProblemsService
    {
         void Create(string name,int points);

        IEnumerable<ProblemViewModel> GetAllProblemsHomePage();

        string getNameById(string id);

        ProblemDetailsViewModel GetProblemDetails(string problemId);
    }
}
