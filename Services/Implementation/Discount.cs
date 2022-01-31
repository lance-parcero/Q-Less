using Microsoft.EntityFrameworkCore;
using Models.Tables;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation {
  public class Discount : IDiscount {
    QLessContext _qLess;
    public Discount(QLessContext qLess) {
      _qLess = qLess;
    }
    public async Task<List<tbl_card_discount_map>> GetDiscounts(int cardTypeId) {
      return await _qLess.tbl_card_discount_map.Include(o => o.Discount).ToListAsync();
    }

  }
}
