using Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLessWeb.ViewModel {
  public class CreatePassengerVM {
    public tbl_passenger Passenger { get; set; }
    public IEnumerable<ref_classification> Classification { get; set; }
    public IEnumerable<tbl_cardtypes> CardTypes { get; set; }
  }
}
