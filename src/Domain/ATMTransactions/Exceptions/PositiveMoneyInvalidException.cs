namespace Domain.ATMTransactions.Exceptions
{
    using Domain.Base.Exceptions;

    public class PositiveMoneyInvalidException : DomainException
    {
        public PositiveMoneyInvalidException(decimal value)
            : base($"Given currency value {value} cannot be negative or zero.")
        {

        }
    }
}
