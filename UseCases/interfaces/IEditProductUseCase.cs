using CoreBusiness;

namespace UseCases
{
    public interface IEditProductUseCase
    {
        void Execute(int productId, Product product);
    }
}