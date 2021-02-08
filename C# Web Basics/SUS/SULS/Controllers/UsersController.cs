using SULS.Data;
using SULS.Services;
using SULS.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SULS.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService service;

        public UsersController(IUsersService service)
        {
            this.service = service;
        }
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost("/Users/Register")]
        public HttpResponse Register(RegisterInputModel user)
        {
            if (!service.IsUsernameAvailable(user.Username))
            {
                return this.Error("Username is not available!");
            }

            if (!service.IsEmailAvailable(user.Email))
            {
                return this.Error("Email is not available!");
            }

            if(string.IsNullOrWhiteSpace(user.Username) || user.Username.Length < 5
                ||user.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 symbols!");
            }

            if(!new EmailAddressAttribute().IsValid(user.Email) || string.IsNullOrWhiteSpace(user.Email))
            {
                return this.Error("Email address is not valid!");
            }

            if(string.IsNullOrWhiteSpace(user.Password) || user.Password.Length < 6 || user.Password.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 symbols!");
            }

            if(user.Password != user.ConfirmPassword)
            {
                return this.Error("Passwords do not match!");
            }

            service.DoRegister(user.Username, user.Password, user.Email);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost("/Users/Login")]
        public HttpResponse Login(string username,string password)
        {
           var userId =  service.GetUserId(username, password);

            if(userId == null)
            {
                return this.Error("Invalid username or password!");
            }

            this.SignIn(userId);

            return this.Redirect("/");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
