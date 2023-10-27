using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IProductRepository productRepository;        

        public RecordTransactionUseCase(
            ITransactionRepository transactionRepository,
            IProductRepository productRepository)
        {
            this.transactionRepository = transactionRepository;
            this.productRepository = productRepository;            
        }

        public void Execute(string cashierName, int productId, int qty)
        {
            var product = productRepository.GetProductById(productId);
            if (product != null)
                transactionRepository.Add(
                    cashierName, 
                    productId, 
                    product.Name, 
                    product.Price.HasValue?product.Price.Value:0,
                    product.Quantity.HasValue?product.Quantity.Value:0, qty);
        }
    }
}
