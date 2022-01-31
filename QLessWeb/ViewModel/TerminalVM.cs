using Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLessWeb.ViewModel {
  public class TerminalVM {

    public tbl_passenger Passenger { get; set; }
    public IEnumerable<tbl_transactions> Transactions { get; set; }

  }
}
