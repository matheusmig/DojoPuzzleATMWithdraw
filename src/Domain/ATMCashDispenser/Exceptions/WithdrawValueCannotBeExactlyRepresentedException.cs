namespace Domain.ATMCashDispenser.Exceptions
{
    using Domain.Base.Exceptions;

    public class WithdrawValueCannotBeExactlyRepresentedException : DomainException
    {
        public WithdrawValueCannotBeExactlyRepresentedException(decimal value)
            : base($"Withdraw value {value} cannot be exactly represented with current bill values")
        {

        }
    }
}
