using CoreBusiness;

namespace UseCases
{
    public interface IGetProductByIdUseCase
    {
        Product? Execute(int productId);
    }
}