using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = CategoriesRepository.GetCategories()              
            };
            return View(salesViewModel);
        }

        public IActionResult SellProductPartial(int productId)
        {
            var product = ProductsRepository.GetProductById(productId);
            return PartialView("_SellProduct", product);
        }

        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            if (ModelState.IsValid)
            {
                // Sell the product
            }

            var product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
            salesViewModel.SelectedCategoryId = (product?.CategoryId == null) ? 0 : product.CategoryId.Value;
            salesViewModel.Categories = CategoriesRepository.GetCategories();

            return View("Index", salesViewModel);
        }
    }
}
