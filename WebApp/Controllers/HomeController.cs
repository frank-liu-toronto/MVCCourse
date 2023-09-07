using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello World from Action Method.";
        }

        public string Error()
        {
            return "I have an error here.";
        }
    }
}
