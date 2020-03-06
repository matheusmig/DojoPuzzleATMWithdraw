namespace Domain.ATMTransactions.ValueObjects
{
    using Domain.Base.ValueObjects;
    using Domain.ATMTransactions.Exceptions;
    using System.Collections.Generic;

    public class PositiveMoney : ValueObject
    {
        public decimal Value { get; private set; }

        private PositiveMoney()
        {
        }

        public PositiveMoney(decimal value)
        {
            if (value <= 0)
                throw new PositiveMoneyInvalidException(value);

            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
