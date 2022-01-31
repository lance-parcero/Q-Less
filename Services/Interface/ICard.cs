using Models.Tables;
using System.Collections.Generic;

namespace Services.Implementation {
  public interface ICard {
    string Generate(int cardType);
    tbl_cardtypes GetDetail(int cardType);
    IEnumerable<tbl_cardtypes> GetCardtypes();
  }
}