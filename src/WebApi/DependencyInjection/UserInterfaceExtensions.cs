namespace WebApi.DependencyInjection
{
    using Application.ATMTransactions.UseCases.Register.Boundaries;
    using Microsoft.Extensions.DependencyInjection;
    using WebApi.UseCases.ATMTransactions.Withdraw;

    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<WithdrawPresenter, WithdrawPresenter>();
            services.AddScoped<IWithdrawTransactionOutputPort>(x => x.GetRequiredService<WithdrawPresenter>());

            return services;
        }
    }
}
