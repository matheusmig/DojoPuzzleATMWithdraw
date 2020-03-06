using Domain.ATMCashDispenser;
using Domain.ATMTransactions;

namespace UnitTests
{
    public sealed class StandardFixture
    {
        public StandardFixture()
        {
            ATMCashDispenserService = new ATMCashDispenserService();
            ATMTransactionService = new ATMTransactionService(ATMCashDispenserService);
        }

        public ATMCashDispenserService ATMCashDispenserService { get; }

        public ATMTransactionService ATMTransactionService { get; }
    }
}
