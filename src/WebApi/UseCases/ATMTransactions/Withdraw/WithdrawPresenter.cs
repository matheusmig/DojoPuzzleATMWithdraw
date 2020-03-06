using Application.ATMTransactions.UseCases.Register.Boundaries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.ATMTransactions.Withdraw
{
    public sealed class WithdrawPresenter : IWithdrawTransactionOutputPort
    {
        public IActionResult ViewModel { get; private set; }
        public WithdrawResponse WithdrawResponse { get; private set; }

        public void BillsATMInsufficientQuantity(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }

        public void BillsInvalidValue(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }

        public void Standard(WithdrawTransactionOutput output)
        {
            WithdrawResponse = new WithdrawResponse(output.BillQuantities);

            ViewModel = new OkObjectResult(WithdrawResponse);
        }
    }
}
