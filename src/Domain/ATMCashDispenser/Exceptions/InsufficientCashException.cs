namespace Domain.ATMCashDispenser.Exceptions
{
    using Domain.Base.Exceptions;

    public class InsufficientCashException : DomainException
    {
        public InsufficientCashException(decimal value)
            : base($"Cash dispenser has less then \"{value}\"")
        {

        }
    }
}
