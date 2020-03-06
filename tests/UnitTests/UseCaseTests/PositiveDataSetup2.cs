using Domain.ATMCashDispenser;
using Domain.ATMTransactions.Entities;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.UseCaseTests
{
    internal sealed class PositiveDataSetup2 : TheoryData<decimal, IEnumerable<BillQuantity>>
    {
        public PositiveDataSetup2()
        {
            var resp = new List<BillQuantity>() {
                new BillQuantity()
                {
                    Bill = new Bill(100.00m),
                    Quantity = 1
                },
                new BillQuantity()
                {
                    Bill = new Bill(50.00m),
                    Quantity = 1
                },
                new BillQuantity()
                {
                    Bill = new Bill(20.00m),
                    Quantity = 1
                },
                new BillQuantity()
                {
                    Bill = new Bill(10.00m),
                    Quantity = 1
                }
            };

            this.Add(180.00m, resp);
        }
    }
}
