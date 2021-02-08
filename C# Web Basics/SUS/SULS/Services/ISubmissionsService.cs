using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Services
{
    public interface ISubmissionsService
    {
        void Create(string problemId, string userId, string code);

        void Delete(string id);
    }
}
