namespace UseCases
{
    public interface IRecordTransactionUseCase
    {
        void Execute(string cashierName, int productId, int qty);
    }
}