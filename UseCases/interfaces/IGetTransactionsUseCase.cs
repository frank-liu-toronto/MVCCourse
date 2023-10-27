using CoreBusiness;
using System;
using System.Collections.Generic;

namespace UseCases
{
    public interface IGetTransactionsUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate);
    }
}