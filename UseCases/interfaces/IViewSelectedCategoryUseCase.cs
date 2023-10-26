using CoreBusiness;

namespace UseCases.CategoriesUseCases
{
    public interface IViewSelectedCategoryUseCase
    {
        Category? Execute(int categoryId);
    }
}