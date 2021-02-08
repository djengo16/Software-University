using BattleCardsExam.Services;
using BattleCardsExam.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;

namespace BattleCardsExam.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (!IsUserSignedIn())
            {
                return this.View();
            }

            return this.Redirect("/");
        }

        [HttpPost("/Users/Login")]
        public HttpResponse DoLogin(string username,string password)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var userId = usersService.GetUserId(username, password);
            
            if(userId == null)
            {
                return this.Error("Invalid username or password!");
            }

            this.SignIn(userId);
            
            return this.Redirect("/Cards/All");
        }

        public HttpResponse Register()
        {
            if (!IsUserSignedIn())
            {
                return this.View();
            }
            
            return this.Redirect("/");
        }

        [HttpPost("/Users/Register")]
        public HttpResponse DoRegister(InputUserModel user)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            if (string.IsNullOrEmpty(user.Username))
            {
                return this.Error("Username is required!");
            }
            if (user.Username.Length < 5 || user.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 symbols!");
            }

            if (!usersService.IsUsernameAvailable(user.Username))
            {
                return this.Error("Please enter another username!");
            }

            if (!usersService.IsEmailAvailable(user.Email))
            {
                return this.Error("The email is already used!");
            }


            if (string.IsNullOrEmpty(user.Email))
            {
                return this.Error("Email is required!");
            }

            if(string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.ConfirmPassword))
            {
                return this.Error("Enter password and confirm password!");
            }

            if(user.Password.Length < 6 || user.Password.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 symbols!");
            }

            if(user.Password != user.ConfirmPassword)
            {
                return this.Error("Passwords do not match!");
            }

            usersService.Create(user.Username, user.Password, user.Email);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Online signed in users can logout!");
            }

            this.SignOut();

            return this.Redirect("/");
        }
        
    }
}
