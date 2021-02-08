using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.ViewModels
{
    public class ProblemDetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<SubmissionViewModel> Submissions { get; set; }
    }
}
