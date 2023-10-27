using CoreBusiness;

namespace UseCases
{
    public interface IViewSelectedProductUseCase
    {
        Product? Execute(int productId);
    }
}