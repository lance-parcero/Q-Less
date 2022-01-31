using Models.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface {
  public interface ITransaction {
    Task<string> Deduct(string cardNumber);

    IEnumerable<tbl_transactions> GetLastTransactions(string cardNumber, int transactionCount);
  }
}
