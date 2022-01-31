using Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Implementation {
  public class Card :  ICard {

    QLessContext _qLess;
    public Card(QLessContext qLess) {
      _qLess = qLess;
    }

    public string Generate(int cardType) {
      var year = DateTime.Now.Year.ToString();
      var cardnumber = year + cardType.ToString() + CreateDigitString(11);
      return cardnumber;
    }
    public tbl_cardtypes GetDetail(int cardType) {
      var detail = _qLess.tbl_cardtypes.Find(cardType);
      return detail;
    }

    private static Random RNG = new Random();
    private string CreateDigitString(int count) {
      var builder = new StringBuilder();
      while (builder.Length < count)
        builder.Append(RNG.Next(10).ToString());
      return builder.ToString();
    }

    public IEnumerable<tbl_cardtypes> GetCardtypes() {
      return _qLess.tbl_cardtypes.ToList();
    }

    

  }
}
