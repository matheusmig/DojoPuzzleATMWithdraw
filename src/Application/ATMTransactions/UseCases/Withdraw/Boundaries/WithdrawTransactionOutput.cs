namespace Application.ATMTransactions.UseCases.Register.Boundaries
{
    using Application.Base.Boundaries;
    using Domain.ATMCashDispenser;
    using System.Collections.Generic;

    public sealed class WithdrawTransactionOutput : IUseCaseOutput
    {
        public WithdrawTransactionOutput(IEnumerable<BillQuantity> billQuantities)
        {

            BillQuantities = billQuantities;
        }


        public IEnumerable<BillQuantity> BillQuantities { get; }
    }
}
