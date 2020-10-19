using SharedTrip.Data;
using SharedTrip.Services;
using SUS.HTTP;
using SUS.MvcFramework;


namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost("/Users/Register")]
        public HttpResponse Register(string username, string password, string confirmPassword, string email)
        {

            if (username.Length < 5 || username.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (string.IsNullOrEmpty(username))
            {
                return this.Redirect("/Users/Register");
            }

            if (string.IsNullOrEmpty(password))
            {
                return this.Redirect("/Users/Register");
            }

            if (password.Length < 6 || password.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (password != confirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            if (!usersService.IsEmailAvailable(email))
            {
                return this.Redirect("/Users/Register");
            }

            if (!usersService.IsUsernameAvailable(username))
            {
                return this.Redirect("/Users/Register");
            }

            usersService.DoRegister(username, password, email);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost("/Users/Login")]
        public HttpResponse Login(string username, string password)
        {
            
            var userId = usersService.GetUserId(username, password);
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }



            this.SignIn(userId);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
