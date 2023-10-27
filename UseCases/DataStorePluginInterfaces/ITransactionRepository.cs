using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        public IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date);        
        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime dateTime);
        public void Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty);
    }
}
