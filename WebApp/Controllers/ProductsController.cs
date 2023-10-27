using CoreBusiness;
using Microsoft.AspNetCore.Mvc;
using UseCases;
using UseCases.CategoriesUseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductsUseCases;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAddProductUseCase addProductUseCase;
        private readonly IEditProductUseCase editProductUseCase;
        private readonly IDeleteProductUseCase deleteProductUseCase;
        private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
        private readonly IViewProductsUseCase viewProductsUseCase;
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IViewProductsInCategoryUseCase viewProductsInCategoryUseCase;

        public ProductsController(
            IAddProductUseCase addProductUseCase,
            IEditProductUseCase editProductUseCase,
            IDeleteProductUseCase deleteProductUseCase,
            IViewSelectedProductUseCase viewSelectedProductUseCase,
            IViewProductsUseCase viewProductsUseCase,
            IViewCategoriesUseCase viewCategoriesUseCase,
            IViewProductsInCategoryUseCase viewProductsInCategoryUseCase)
        {
            this.addProductUseCase = addProductUseCase;
            this.editProductUseCase = editProductUseCase;
            this.deleteProductUseCase = deleteProductUseCase;
            this.viewSelectedProductUseCase = viewSelectedProductUseCase;
            this.viewProductsUseCase = viewProductsUseCase;
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.viewProductsInCategoryUseCase = viewProductsInCategoryUseCase;
        }

        public IActionResult Index()
        {
            var products = viewProductsUseCase.Execute(loadCategory: true);
            return View(products);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";

            var productViewModel = new ProductViewModel
            {
                Categories = viewCategoriesUseCase.Execute()
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                addProductUseCase.Execute(productViewModel.Product);                
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "add";
            productViewModel.Categories = viewCategoriesUseCase.Execute();
            return View(productViewModel);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";

            var productViewModel = new ProductViewModel
            {
                Product = viewSelectedProductUseCase.Execute(id)??new Product(),
                Categories = viewCategoriesUseCase.Execute()
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                editProductUseCase.Execute(productViewModel.Product.ProductId, productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "edit";
            productViewModel.Categories = viewCategoriesUseCase.Execute();
            return View(productViewModel);
        }

        public IActionResult Delete(int id)
        {
            deleteProductUseCase.Execute(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductsByCategoryPartial(int categoryId)
        {
            var products = viewProductsInCategoryUseCase.Execute(categoryId);

            return PartialView("_Products", products);
        }
    }
}
