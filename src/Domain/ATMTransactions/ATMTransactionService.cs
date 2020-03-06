namespace Domain.ATMTransactions
{
    using Domain.ATMCashDispenser;
    using Domain.ATMTransactions.Exceptions;
    using Domain.ATMTransactions.ValueObjects;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ATMTransactionService
    {
        private readonly IATMCashDispenserService _atmCashDispenserService;

        public ATMTransactionService(IATMCashDispenserService atmCashDispenserService)
        {
            _atmCashDispenserService = atmCashDispenserService;
        }

        public async Task<IEnumerable<BillQuantity>> WithdrawAsync(PositiveMoney positiveCurrency)
        {
           return _atmCashDispenserService.Withdraw(positiveCurrency);
        }
    }
}
