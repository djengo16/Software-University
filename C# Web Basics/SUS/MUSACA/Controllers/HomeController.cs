using SUS.HTTP;
namespace MUSACA.Controllers
{
    using SUS.MvcFramework;
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}
