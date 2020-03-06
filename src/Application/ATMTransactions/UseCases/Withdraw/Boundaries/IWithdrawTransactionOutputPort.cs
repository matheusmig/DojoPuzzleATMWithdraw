namespace Application.ATMTransactions.UseCases.Register.Boundaries
{
    using Application.Base.Boundaries;

    public interface IWithdrawTransactionOutputPort : IOutputPortStandard<WithdrawTransactionOutput>
    {
        void BillsATMInsufficientQuantity(string message);
        void BillsInvalidValue(string message);
    }
}
