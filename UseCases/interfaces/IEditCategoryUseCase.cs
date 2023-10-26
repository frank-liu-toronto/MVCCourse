using CoreBusiness;

namespace UseCases.CategoriesUseCases
{
    public interface IEditCategoryUseCase
    {
        void Execute(int categoryId, Category category);
    }
}