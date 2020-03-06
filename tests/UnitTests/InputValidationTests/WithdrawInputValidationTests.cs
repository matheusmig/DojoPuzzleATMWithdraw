using Application.ATMTransactions.UseCases.Register.Boundaries;
using Domain.ATMTransactions.Exceptions;
using Domain.ATMTransactions.ValueObjects;
using System;
using Xunit;

namespace UnitTests.InputValidationTests
{
    public sealed class WithdrawInputValidationTests
    {
        [Fact]
        public void GivenZeroValue_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<PositiveMoneyInvalidException>(
                () => new WithdrawTransactionInput(new PositiveMoney(0)));

            Assert.Contains("zero", actualEx.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void GivenNegativeValue_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<PositiveMoneyInvalidException>(
                () => new WithdrawTransactionInput(new PositiveMoney(-10)));

            Assert.Contains("negative", actualEx.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new WithdrawTransactionInput(
                new PositiveMoney(10));

            Assert.NotNull(actual);
        }
    }
}
