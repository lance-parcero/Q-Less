using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLessWeb.Controllers {
  public class LoadingController : Controller {

    IQLessSvc _qLess;
    public LoadingController(IQLessSvc qLess) {
      _qLess = qLess;
    }

    public IActionResult Card(string id) {
       var model =  _qLess.GetPassengerDetail(id);
      return View(model);
    }

    [HttpPost]
    public IActionResult Load(string cardNumber,decimal load) {
      var model = _qLess.LoadPassenger(cardNumber, load);
      return Json(model);
    }

  }
}
