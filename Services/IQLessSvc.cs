using Models.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services {
  public interface IQLessSvc {
    string EnrollPassenger(tbl_passenger passenger);
    tbl_passenger GetPassengerDetail(string cardNumber);
    IEnumerable<tbl_passenger> GetPassengers();
    decimal LoadPassenger(string cardNumber, decimal load);
    IEnumerable<tbl_cardtypes> GetCardtypes();
    IEnumerable<ref_classification> GetClassifications();
    Task<string> Deduct(string cardNumber);
    IEnumerable<tbl_transactions> GetTransactions(string cardNumber);
  }
}
