using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int? id) 
        {
            if (id.HasValue)
                return new ContentResult { Content = id.ToString() };
            else
                return new ContentResult { Content = "null content" };
        }

    }
}
