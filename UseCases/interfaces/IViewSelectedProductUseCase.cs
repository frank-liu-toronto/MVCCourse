using CoreBusiness;

namespace UseCases
{
    public interface IViewSelectedProductUseCase
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}