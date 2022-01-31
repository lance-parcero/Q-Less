using Microsoft.Extensions.Configuration;
using Models.Constants;
using Models.Tables;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class Transaction : ITransaction
    {
        QLessContext _qLess;
        IPassenger _passenger;
        IDiscount _discount;
        IConfiguration _config;
        public Transaction(QLessContext qLess, IPassenger passenger, IDiscount discount, IConfiguration config)
        {
            _qLess = qLess;
            _passenger = passenger;
            _discount = discount;
            _config = config;
        }

        public async Task<string> Deduct(string cardNumber)
        {
            var detail = _passenger.GetPassengerDetail(cardNumber);
            decimal balance = detail.Balance;
            decimal baseRate = detail.CardType.BaseRate ?? 0;
            decimal totalDiscount = 0;

            if (detail.CardExpiry < DateTime.Now)
            {
                return "Card Expired. Please contact administrator.";
            }

            var transactions = GetLastTransactions(cardNumber, 10); // 1 roundtrip  = 2

            if (CardTypes.TypeB == detail.CardTypeID)
            {
                var discounts = await _discount.GetDiscounts(detail.CardTypeID);
                //foreach (var disc in discounts.Where(o => o.Discount.DiscountType == DiscountTypes.ByAmount)) {
                //  totalDiscount = baseRate - disc
                //}
                var listPercentage = discounts.Where(o => o.Discount.DiscountType == DiscountTypes.ByPercentage);
                decimal highestPercentage = 0;
                if (listPercentage.Any())
                {
                    highestPercentage = listPercentage.OrderBy(o => o.Discount.DiscountValue).FirstOrDefault().Discount.DiscountValue;
                    totalDiscount = baseRate * ((highestPercentage / 100));
                }
                //SECTION C-LESS DISCOUNT
                var transactionsToday = transactions.Where(o => o.TimeOfEntry.Date == DateTime.Now.Date).ToList();
                if (transactionsToday.Count() >= 2 && transactionsToday.Count() % 2 == 0 && transactionsToday.Count() < 9)
                { //discount only on entry per 4 trips
                    Decimal.TryParse(_config["ConsecutiveTripDiscount"], out decimal addDiscount);
                    totalDiscount = baseRate * ((highestPercentage + addDiscount) / 100);
                }
            }
            var entryType = "";
            var lastTransaction = transactions.OrderByDescending(o => o.TimeOfEntry).FirstOrDefault();
            var deduction = baseRate - totalDiscount;

            if (balance - deduction < 0 && lastTransaction.TypeOfEntry == TypeOfEntry.OUT)
                return "Insufficient Balance - Please contact administrator.";


            if (lastTransaction == null || lastTransaction.TypeOfEntry == TypeOfEntry.OUT)
            {
                entryType = TypeOfEntry.IN;
                _passenger.UpdateBalance(cardNumber, deduction);
                var newLoad = balance - deduction;
                AddTransaction(cardNumber, entryType, balance, newLoad, deduction, baseRate, totalDiscount);
                return "Entry type :" + entryType + " Load(" + newLoad.ToString() + ")" + " Base Rate" + (baseRate).ToString() + " Total Discount" + (totalDiscount).ToString();
            }
            else
            {
                entryType = TypeOfEntry.OUT;
                AddTransaction(cardNumber, entryType, balance, balance, 0, baseRate, 0);
                return "Entry type :" + entryType + " Load(" + balance + ")";
            }
            return "Something went wrong";
            //_qLess.tbl_transactions.
        }

        private void AddTransaction(string cardNumber, string typeOfEntry, decimal currentLoad, decimal newLoad, decimal deduction, decimal currentRate, decimal discount)
        {
            var randomStation = _qLess.tbl_station.OrderBy(o => Guid.NewGuid()).FirstOrDefault().StationID;
            var newTransaction = new tbl_transactions
            {
                CardNumber = cardNumber,
                TimeOfEntry = DateTime.Now,
                TypeOfEntry = typeOfEntry,
                StationID = randomStation,
                CurrentLoad = currentLoad,
                NewLoad = newLoad,
                Deduction = deduction,
                CurrentRate = currentRate,
                Discount = discount
            };
            _qLess.tbl_transactions.Add(newTransaction);
            _qLess.SaveChanges();
        }

        public IEnumerable<tbl_transactions> GetLastTransactions(string cardNumber, int transactionCount)
        {
            return _qLess.tbl_transactions.OrderByDescending(o => o.TimeOfEntry).Where(o => o.CardNumber == cardNumber).Take(transactionCount).ToList();
        }





    }
}
