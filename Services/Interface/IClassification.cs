using Models.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface {
  public interface IClassification {
    IEnumerable<ref_classification> GetClassifications();
  }
}
