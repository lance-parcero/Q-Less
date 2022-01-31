using Models.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface {
  public interface IDiscount {
    Task<List<tbl_card_discount_map>> GetDiscounts(int cardTypeId);
    }
}
