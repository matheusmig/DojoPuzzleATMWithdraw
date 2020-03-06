using Application.Base.Boundaries;
using Domain.ATMTransactions.ValueObjects;

namespace Application.ATMTransactions.UseCases.Register.Boundaries
{
    public sealed class WithdrawTransactionInput : IUseCaseInput
    {
        public WithdrawTransactionInput(PositiveMoney value)
        {
            Value = value;
        }

        public PositiveMoney Value { get; }
    }
}
