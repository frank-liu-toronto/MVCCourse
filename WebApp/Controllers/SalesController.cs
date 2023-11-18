using Microsoft.AspNetCore.Mvc;
using CoreBusiness;
using WebApp.ViewModels;
using UseCases.CategoriesUseCases;
using UseCases;
using Microsoft.AspNetCore.Authorization;
using UseCases.ProductsUseCases;

namespace WebApp.Controllers
{
    [Authorize(Policy = "Cashiers")]
    public class SalesController : Controller
    {
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
        private readonly ISellProductUseCase sellProductUseCase;
        private readonly IViewProductsInCategoryUseCase viewProductsInCategoryUseCase;

        public SalesController(IViewCategoriesUseCase viewCategoriesUseCase,
            IViewSelectedProductUseCase viewSelectedProductUseCase,
            ISellProductUseCase sellProductUseCase,
            IViewProductsInCategoryUseCase viewProductsInCategoryUseCase)
        {
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.viewSelectedProductUseCase = viewSelectedProductUseCase;
            this.sellProductUseCase = sellProductUseCase;
            this.viewProductsInCategoryUseCase = viewProductsInCategoryUseCase;
        }

        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = viewCategoriesUseCase.Execute()              
            };
            return View(salesViewModel);
        }

        public IActionResult SellProductPartial(int productId)
        {
            var product = viewSelectedProductUseCase.Execute(productId);
            return PartialView("_SellProduct", product);
        }

        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            if (ModelState.IsValid)
            {
                // Sell the product
                sellProductUseCase.Execute(
                    "cashier1",
                    salesViewModel.SelectedProductId,
                    salesViewModel.QuantityToSell);                
            }

            var product = viewSelectedProductUseCase.Execute(salesViewModel.SelectedProductId);
            salesViewModel.SelectedCategoryId = (product?.CategoryId == null) ? 0 : product.CategoryId.Value;
            salesViewModel.Categories = viewCategoriesUseCase.Execute();
            
            return View("Index", salesViewModel);
        }

        public IActionResult ProductsByCategoryPartial(int categoryId)
        {
            var products = viewProductsInCategoryUseCase.Execute(categoryId);

            return PartialView("_Products", products);
        }
    }
}
