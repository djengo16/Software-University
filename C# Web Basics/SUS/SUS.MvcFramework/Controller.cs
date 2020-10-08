using SUS.HTTP;
using System.Runtime.CompilerServices;
using System.Text;

namespace SUS.MvcFramework
{
    public abstract class Controller
    {
        public HttpResponse View([CallerMemberNameAttribute]string viewPath = null)
        {
            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");

            int controllerLength = "Controller".Length - 1;

            var viewContent = System.IO.File
                .ReadAllText("Views/" 
                + this.GetType().Name.Remove(this.GetType().Name.Length - controllerLength) // Removing the "Controller" part.
                + "/" + viewPath + ".cshtml");

            var responseHtml = layout.Replace("@RenderBody", viewContent);

            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
            return response;

        }

        public HttpResponse File(string filePath,string contentType )
        {            
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var response = new HttpResponse(contentType, fileBytes);
            return response;
        }

        public HttpResponse Redirect(string url)
        {
            var response = new HttpResponse(System.Net.HttpStatusCode.Found);
            response.Headers.Add(new Header("Location", url));
            return response;
        }
    }

}
