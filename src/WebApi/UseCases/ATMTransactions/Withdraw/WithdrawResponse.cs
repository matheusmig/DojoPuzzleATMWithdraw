namespace WebApi.UseCases.ATMTransactions.Withdraw
{
    using Domain.ATMCashDispenser;
    using System.Collections.Generic;

    public sealed class WithdrawResponse
    {
        public WithdrawResponse(
            IEnumerable<BillQuantity> billQuantities)
        {
            BillQuantities = billQuantities;
        }

        public IEnumerable<BillQuantity> BillQuantities { get; }
    }
}
