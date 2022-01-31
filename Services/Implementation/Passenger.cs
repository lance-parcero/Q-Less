using Microsoft.EntityFrameworkCore;
using Models.Tables;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Implementation {
  public class Passenger : IPassenger {
    QLessContext _qLess;
    public Passenger(QLessContext qLess) {
      _qLess = qLess;
    }
    public string AddPassenger(tbl_passenger passenger) {
      _qLess.tbl_passenger.Add(passenger);
      _qLess.SaveChanges();
      return passenger.CardNumber;
    }
    public IQueryable<tbl_passenger> GetPassengers() {
      return _qLess.tbl_passenger.Include(o => o.CardType).Include(p => p.Classification);
    }
    public tbl_passenger GetPassengerDetail(string cardNumber) {
      return _qLess.tbl_passenger.Include(o => o.CardType).Include(p => p.Classification).Single(o=>o.CardNumber == cardNumber);
    }

    public tbl_passenger UpdateBalance(string cardNumber,decimal deduction) {
      var passenger = _qLess.tbl_passenger.FirstOrDefault(o => o.CardNumber == cardNumber);
      passenger.Balance = passenger.Balance - deduction;
      _qLess.SaveChanges();
      return passenger;
    }
  }
}
