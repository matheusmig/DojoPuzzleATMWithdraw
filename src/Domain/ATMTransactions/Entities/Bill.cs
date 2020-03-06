namespace Domain.ATMTransactions.Entities
{
    public class Bill : IBill
    {
        public decimal Value { get; set; }

        public Bill(decimal value)
        {
            Value = value;
        }
    }
}
