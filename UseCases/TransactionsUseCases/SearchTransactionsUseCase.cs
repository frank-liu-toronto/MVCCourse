using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class SearchTransactionsUseCase : ISearchTransactionsUseCase
    {
        private readonly ITransactionRepository transactionRepository;

        public SearchTransactionsUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> Execute(
            string cashierName,
            DateTime startDate,
            DateTime endDate
            )
        {
            return transactionRepository.Search(cashierName, startDate, endDate);
        }
    }
}
