using Microsoft.EntityFrameworkCore;
using Models.Custom;
using Models.Tables;
using Services.Implementation;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services {
  public class QLessSvc : IQLessSvc {

    ICard _cardSvc;
    IPassenger _passengerSvc;
    IClassification _classySvc;
    ITransaction _transSvc;
    public QLessSvc(IPassenger passengerSvc, ICard cardSvc, IClassification classySvc, ITransaction transSvc) {
      _passengerSvc = passengerSvc;
      _cardSvc = cardSvc;
      _classySvc = classySvc;
      _transSvc = transSvc;
    }
    #region Passenger
    public IEnumerable<tbl_passenger> GetPassengers() {
      return _passengerSvc.GetPassengers().OrderByDescending(o=>o.CreatedTimestamp).ToList();
    }
    public tbl_passenger GetPassengerDetail(string cardNumber) {
      return _passengerSvc.GetPassengers().FirstOrDefault(o => o.CardNumber == cardNumber);
    }
    public string EnrollPassenger(tbl_passenger passenger) {
      passenger.CardNumber = _cardSvc.Generate(passenger.CardTypeID);
      var cardDetails = _cardSvc.GetDetail(passenger.CardTypeID);
      passenger.Balance = cardDetails.InitialLoad ?? 0;

      if ((cardDetails.Validity ?? 0) > 0)
        passenger.CardExpiry = DateTime.Now.AddYears(cardDetails.Validity.Value);
      _passengerSvc.AddPassenger(passenger);
      return passenger.CardNumber;
    }

    public decimal LoadPassenger(string cardNumber,decimal load) {
      var passenger = _passengerSvc.UpdateBalance(cardNumber, load * -1);
      return passenger.Balance;
    }
    #endregion

    #region Card
    public IEnumerable<tbl_cardtypes> GetCardtypes() {
      return _cardSvc.GetCardtypes();
    }
    #endregion

    #region Classification
    public IEnumerable<ref_classification> GetClassifications() {
      return _classySvc.GetClassifications();
    }
    #endregion

    #region Transaction
    public async Task<string> Deduct(string cardNumber) {
      return await _transSvc.Deduct(cardNumber);
    }

    public IEnumerable<tbl_transactions> GetTransactions(string cardNumber) {
      return _transSvc.GetLastTransactions(cardNumber, 10);
    }
    #endregion


  }
}
