using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Tables;
using QLessWeb.Models;
using QLessWeb.ViewModel;
using Services;
using Services.Implementation;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QLessWeb.Controllers {
  public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;
    private readonly IQLessSvc _svc;
    public HomeController(ILogger<HomeController> logger, IQLessSvc svc) {
      _logger = logger;
      _svc = svc;
    }

    public IActionResult Index() {
      var passengers = _svc.GetPassengers();
      return View(passengers);
    }

    public IActionResult Enroll() {
      var vm = new CreatePassengerVM {
        CardTypes = _svc.GetCardtypes(),
        Classification = _svc.GetClassifications()
      };
      return View(vm);
    }

    [HttpPost]
    public IActionResult Save(tbl_passenger passenger) {
      var cardNumber = _svc.EnrollPassenger(passenger);
      return Json(cardNumber);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
