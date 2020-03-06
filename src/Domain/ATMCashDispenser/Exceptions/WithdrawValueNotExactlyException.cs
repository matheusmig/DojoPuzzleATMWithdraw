namespace Domain.ATMCashDispenser.Exceptions
{
    using Domain.Base.Exceptions;

    public class WithdrawValueNotExactlyException : DomainException
    {
        public WithdrawValueNotExactlyException(decimal value)
            : base($"Withdraw value {value} cannot be exactly aproximited with current bill values")
        {

        }
    }
}
