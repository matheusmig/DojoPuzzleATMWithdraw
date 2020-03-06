using Microsoft.Extensions.DependencyInjection;
using WebApi.Filters;

namespace WebApi.DependencyInjection
{
    public static class BusinessExceptionExtensions
    {
        public static IServiceCollection AddBusinessExceptionFilter(this IServiceCollection services)
        {
            services.AddMvc(options => { options.Filters.Add(typeof(BusinessExceptionFilter)); });

            return services;
        }
    }
}
