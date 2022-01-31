using Models.Tables;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Implementation {
  public class Classification : IClassification {
    QLessContext _qLess;
    public Classification(QLessContext qLess) {
      _qLess = qLess;
    }

    public IEnumerable<ref_classification> GetClassifications() {
      return _qLess.ref_classification.ToList();
    }


  }
}
