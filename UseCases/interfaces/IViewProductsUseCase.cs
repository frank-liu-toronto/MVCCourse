using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IViewProductsUseCase
    {
        IEnumerable<Product> Execute(bool loadCategory = false);
    }
}