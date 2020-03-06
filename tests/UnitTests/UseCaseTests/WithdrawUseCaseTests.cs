using Application.ATMTransactions.UseCases.Register;
using Application.ATMTransactions.UseCases.Register.Boundaries;
using Domain.ATMCashDispenser;
using Domain.ATMCashDispenser.Exceptions;
using Domain.ATMTransactions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UseCases.ATMTransactions.Withdraw;
using Xunit;

namespace UnitTests.UseCaseTests
{
    public sealed class WithdrawTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public WithdrawTests(StandardFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public async Task Withdraw_Valid_Amount(
            decimal amount,
            IEnumerable<BillQuantity> expectedBills)
        {
            var presenter = new WithdrawPresenter();

            var sut = new WithdrawTransactionUseCase(
                presenter,
                _fixture.ATMTransactionService);

            await sut.ExecuteAsync(new WithdrawTransactionInput(
                new PositiveMoney(amount)));

            var actual = presenter.WithdrawResponse;

            Assert.Equal(expectedBills, actual.BillQuantities);
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup2))]
        public async Task Withdraw_Valid_Amount2(
           decimal amount,
           IEnumerable<BillQuantity> expectedBills)
        {
            var presenter = new WithdrawPresenter();

            var sut = new WithdrawTransactionUseCase(
                presenter,
                _fixture.ATMTransactionService);

            await sut.ExecuteAsync(new WithdrawTransactionInput(
                new PositiveMoney(amount)));

            var actual = presenter.WithdrawResponse;

            Assert.Equal(expectedBills, actual.BillQuantities);
        }

        [Theory]
        [ClassData(typeof(NotExactlyDataSetup))]
        public async Task Withdraw_Invalid_NotExactlyAmount(
           decimal amount)
        {
            var presenter = new WithdrawPresenter();

            var sut = new WithdrawTransactionUseCase(
                presenter,
                _fixture.ATMTransactionService);

            var actualEx = await Assert.ThrowsAsync<WithdrawValueCannotBeExactlyRepresentedException>(
                async () => await sut.ExecuteAsync(new WithdrawTransactionInput(
                new PositiveMoney(amount))));

            Assert.Contains("cannot be exactly represente", actualEx.Message, StringComparison.OrdinalIgnoreCase);
        }
    }
}
