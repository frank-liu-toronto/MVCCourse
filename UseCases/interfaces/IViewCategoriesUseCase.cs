using CoreBusiness;

namespace UseCases.CategoriesUseCases
{
    public interface IViewCategoriesUseCase
    {
        IEnumerable<Category> Execute();
    }
}