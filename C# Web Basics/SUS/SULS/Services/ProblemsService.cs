using SULS.Data;
using SULS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext dbContext;

        public ProblemsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(string name,int points)
        {
            this.dbContext.Problems.Add(new Problem
            {
                Name = name,
                Points = points,
            });

            dbContext.SaveChanges();
        }

        public IEnumerable<ProblemViewModel> GetAllProblemsHomePage()
        {
            return this.dbContext.Problems.Select(x => new ProblemViewModel
            {
                Name = x.Name,
                Id = x.Id,
                Count = x.Submissions.Count,
            }).ToList();
               
        }

        public string getNameById(string id)
        {
            var problem = this.dbContext.Problems.FirstOrDefault(x => x.Id == id);

            return problem?.Name;
        }

        public ProblemDetailsViewModel GetProblemDetails(string id)
        {
            return this.dbContext.Problems.Where(x => x.Id == id)
                  .Select(x => new ProblemDetailsViewModel
                  {
                      Name = x.Name,
                      Submissions = x.Submissions.Select(s => new SubmissionViewModel
                      {
                          CreatedOn = s.CreatedOn,
                          SubmissionId = s.Id,
                          AchievedResult = s.AchievedResult,
                          Username = s.User.Username,
                          MaxPoints = x.Points,
                      })
                  }).FirstOrDefault();
        }
    }
}
