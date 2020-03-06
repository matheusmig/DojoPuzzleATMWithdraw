using Domain.ATMTransactions.Entities;
using Domain.ATMTransactions.ValueObjects;
using System.Collections.Generic;

namespace Domain.ATMCashDispenser
{
    public interface IATMCashDispenserService
    {
        IEnumerable<BillQuantity> Withdraw(PositiveMoney positiveCurrency);
    }
}
