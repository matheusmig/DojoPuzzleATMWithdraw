using Application.ATMTransactions.UseCases.Register;
using Domain.ATMCashDispenser;
using Domain.ATMTransactions;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DependencyInjection
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IWithdrawTransactionUseCase, WithdrawTransactionUseCase>();

            services.AddScoped<IATMCashDispenserService, ATMCashDispenserService>();
            services.AddScoped<ATMTransactionService>();

            return services;
        }
    }
}
