using CoreBusiness;

namespace UseCases.ProductsUseCases
{
    public interface IViewProductsInCategoryUseCase
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}