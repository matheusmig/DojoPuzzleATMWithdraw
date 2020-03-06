using Domain.ATMCashDispenser.Exceptions;
using Domain.ATMTransactions.Entities;
using Domain.ATMTransactions.ValueObjects;
using System;
using System.Collections.Generic;

namespace Domain.ATMCashDispenser
{
    public class ATMCashDispenserService : IATMCashDispenserService
    {
        protected IEnumerable<decimal> AvailableBillValues; 

        public ATMCashDispenserService()
        {
            AvailableBillValues = new List<decimal>()
            {
                100.00m,
                50.00m,
                20.00m,
                10.00m
            };
        }

        private bool HasBalance(PositiveMoney value)
        {
            //In this first moment, cash on ATM is infinite
            return true;
        }

        public IEnumerable<BillQuantity> Withdraw(PositiveMoney positiveCurrency)
        {
            if (!HasBalance(positiveCurrency))
                throw new InsufficientCashException(positiveCurrency.Value);

            var outputBillQuantities = new List<BillQuantity>();
            
            var remainingWithdrawValue = positiveCurrency.Value;

            foreach(var availableBillValue in AvailableBillValues)
            {
                var billQuantity = (int) Math.Floor(remainingWithdrawValue / availableBillValue);

                if (billQuantity > 0)
                {
                    outputBillQuantities.Add(new BillQuantity()
                    {
                        Quantity = billQuantity,
                        Bill = new Bill(availableBillValue)
                    });
                }

                remainingWithdrawValue -= availableBillValue * billQuantity;
                if (remainingWithdrawValue == decimal.Zero)
                    break;               
            }

            if (remainingWithdrawValue != 0)
                throw new WithdrawValueCannotBeExactlyRepresentedException(positiveCurrency.Value);

            return outputBillQuantities;
        }

    }
}
