namespace WebApi.UseCases.ATMTransactions.Withdraw
{
    using System.ComponentModel.DataAnnotations;

    public sealed class WithdrawRequest
    {
        [Display(Name = "Value")]
        [Required]
        public decimal? Value { get; set; }
    }
}
