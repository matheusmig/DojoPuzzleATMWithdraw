namespace WebApi.UseCases.ATMTransactions.Withdraw
{
    using Application.ATMTransactions.UseCases.Register;
    using Application.ATMTransactions.UseCases.Register.Boundaries;
    using Domain.ATMTransactions.ValueObjects;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public sealed class ATMTransactionController : ControllerBase
    {
        private readonly IWithdrawTransactionUseCase _useCase;
        private readonly WithdrawPresenter _presenter;

        public ATMTransactionController(
            IWithdrawTransactionUseCase useCase,
            WithdrawPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Withdraw banknotes from ATM.
        /// </summary>
        /// <response code="200">The registered customer was create successfully.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="request">The request to register a employee.</param>
        /// <returns>The newly registered employee.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WithdrawResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromForm] WithdrawRequest request)
        {
            var input = new WithdrawTransactionInput(
                new PositiveMoney(request.Value.Value));

            await _useCase.ExecuteAsync(input);

            return _presenter.ViewModel;
        }
    }
}
