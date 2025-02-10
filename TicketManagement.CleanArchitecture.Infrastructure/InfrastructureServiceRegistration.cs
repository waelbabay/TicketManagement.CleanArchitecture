using Azure;
using Azure.Identity;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using TicketManagement.CleanArchitecture.Application.Contracts.Infrastructure;
using TicketManagement.CleanArchitecture.Infrastructure.AI.Language;

namespace TicketManagement.CleanArchitecture.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ILanguageDetector, AzureLanguageDetector>();

            return services;
        }
    }
}
