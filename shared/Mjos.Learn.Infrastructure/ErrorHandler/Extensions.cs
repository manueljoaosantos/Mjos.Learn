using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Mjos.Learn.Infrastructure.ErrorHandler
{
    public static class Extensions
    {
        public static IServiceCollection AddProblemDetailsDeveloperPageExceptionFilter(this IServiceCollection services) =>
            services.AddSingleton<IDeveloperPageExceptionFilter, ProblemDetailsDeveloperPageExceptionFilter>();
    }
}