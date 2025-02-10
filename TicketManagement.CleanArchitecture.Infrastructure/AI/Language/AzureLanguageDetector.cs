using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.Extensions.Configuration;
using TicketManagement.CleanArchitecture.Application.Contracts.Infrastructure;

namespace TicketManagement.CleanArchitecture.Infrastructure.AI.Language
{
    public class AzureLanguageDetector : ILanguageDetector
    {
        private readonly string _languageService1Key;
        private readonly string _languageService1Endpoint;

        public AzureLanguageDetector(IConfiguration configuration)
        {
            _languageService1Key = configuration["AzureAiServices:LanguageService1Key"];
            _languageService1Endpoint = configuration["AzureAiServices:languageService1Endpoint"];
        }

        public async Task<string> DetectLanguage(string text)
        {
            var textAnalyticsClient = new TextAnalyticsClient(new Uri(_languageService1Endpoint), new AzureKeyCredential(_languageService1Key));

            DetectedLanguage detectedLanguage = await textAnalyticsClient.DetectLanguageAsync(text);

            return detectedLanguage.Name;
        }
    }
}
