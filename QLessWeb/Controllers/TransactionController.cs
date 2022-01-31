using Microsoft.AspNetCore.Mvc;
using Models.Tables;
using QLessWeb.ViewModel;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLessWeb.Controllers {
  public class TransactionController : Controller {
    IQLessSvc _qLess;
    public TransactionController(IQLessSvc qLess) {
      _qLess = qLess;
    }
    public IActionResult Terminal(string id) {
      ViewBag.CardNumber = id;
      var vm = new TerminalVM {
        Passenger = _qLess.GetPassengerDetail(id),
        Transactions = _qLess.GetTransactions(id)
      };
      return View(vm);
    }
    [HttpPost]
    public async Task<IActionResult>Deduct(string cardNumber) {
      return Json(await _qLess.Deduct(cardNumber));
    }

    [HttpPost]
    public IActionResult GetTransactions(string cardNumber) {
      return PartialView("_PartialTransactions",_qLess.GetTransactions(cardNumber));
    }


  }
}
