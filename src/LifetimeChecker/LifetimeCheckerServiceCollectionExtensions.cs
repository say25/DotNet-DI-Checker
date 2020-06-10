using System;
using LifetimeChecker;

// ReSharper disable once CheckNamespace - Microsoft recommends putting IServiceCollection extensions in the Microsoft.Extensions.DependencyInjection namespace.
// @see https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2#code-try-5
namespace Microsoft.Extensions.DependencyInjection
{
    public static class LifetimeCheckerServiceCollectionExtensions
    {
        /// <summary>
        /// Adds DI for LifetimeChecker.csproj.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddLifetimeChecker(this IServiceCollection services)
        {
            // Any needed configuration.

            // My Internal Classes

            // My Public Classes
            services.AddTransient<IOperationTransient, Operation>();
            services.AddScoped<IOperationScoped, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddSingleton<IOperationSingletonInstance>(new Operation(Guid.Empty));

            // OperationService depends on each of the other Operation types.
            services.AddTransient<OperationService, OperationService>();

            return services;
        }
    }
}
