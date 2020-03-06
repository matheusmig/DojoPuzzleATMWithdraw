namespace Application.ATMTransactions.UseCases.Register
{
    using Application.ATMTransactions.UseCases.Register.Boundaries;
    using System.Threading.Tasks;
    using Domain.ATMTransactions;
    using System.Collections.Generic;
    using Domain.ATMTransactions.Entities;
    using Domain.ATMCashDispenser;

    public class WithdrawTransactionUseCase : IWithdrawTransactionUseCase
    {
        private readonly IWithdrawTransactionOutputPort _outputPort;
        private readonly ATMTransactionService _atmTransactionService;

        public WithdrawTransactionUseCase(
            IWithdrawTransactionOutputPort outputPort,
            ATMTransactionService atmTransactionService)
        {
            _outputPort = outputPort;
            _atmTransactionService = atmTransactionService;
        }

        public async Task ExecuteAsync(WithdrawTransactionInput input)
        {
            var bills = await _atmTransactionService.WithdrawAsync(input.Value);

            BuildOutput(bills);
        }

        private void BuildOutput(IEnumerable<BillQuantity> bills)
        {
            _outputPort.Standard(new WithdrawTransactionOutput(
                bills)
            );
        }
    }
}
