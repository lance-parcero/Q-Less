using Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interface {
  public interface IPassenger {

    string AddPassenger(tbl_passenger passenger);
    IQueryable<tbl_passenger> GetPassengers();

    tbl_passenger GetPassengerDetail(string cardNumber);

    tbl_passenger UpdateBalance(string cardNumber, decimal deduction);
  }
}
