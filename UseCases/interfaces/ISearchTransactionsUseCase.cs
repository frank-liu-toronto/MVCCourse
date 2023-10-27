using CoreBusiness;

namespace UseCases
{
    public interface ISearchTransactionsUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate);
    }
}