using Domain.ATMCashDispenser;
using Domain.ATMTransactions.Entities;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.UseCaseTests
{
    internal sealed class PositiveDataSetup : TheoryData<decimal, IEnumerable<BillQuantity>>
    {
        public PositiveDataSetup()
        {
            var resp = new List<BillQuantity>() {
                new BillQuantity()
                {
                    Bill = new Bill(100.00m),
                    Quantity = 2
                }
            };

            this.Add(200.00m, resp);
        }
    }
}
