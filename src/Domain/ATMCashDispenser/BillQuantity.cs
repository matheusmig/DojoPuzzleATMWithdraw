using Domain.ATMTransactions.Entities;
using Domain.ATMTransactions.ValueObjects;
using System;

namespace Domain.ATMCashDispenser
{
    public class BillQuantity : IEquatable<BillQuantity>
    {
        public int Quantity { get; set; }
        public Bill Bill { get; set; }
        public PositiveMoney ValueTotal => new PositiveMoney(Quantity * Bill.Value);

        // IEquatable implementations
        public override bool Equals(object obj)
        {
            if (obj is null) 
                return false;

            if (ReferenceEquals(this, obj)) 
                return true;

            if (obj.GetType() != this.GetType()) 
                return false;

            return Equals((BillQuantity)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + Bill.Value.GetHashCode();
                hash = hash * 23 + Quantity.GetHashCode();
                return hash;
            }
        }

        public bool Equals(BillQuantity other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other)) 
                return true;

            return Bill.Value == other.Bill.Value && Quantity == other.Quantity;
        }
    }
}
