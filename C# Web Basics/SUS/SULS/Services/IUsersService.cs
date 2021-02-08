using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Services
{
    public interface IUsersService
    {
        bool IsEmailAvailable(string email);

        bool IsUsernameAvailable(string username);

        void DoRegister(string username, string password, string email);

        string GetUserId(string username, string password);
    }
}
