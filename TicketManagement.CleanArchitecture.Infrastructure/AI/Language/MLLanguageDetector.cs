using TicketManagement.CleanArchitecture.Application.Contracts.Infrastructure;

namespace TicketManagement.CleanArchitecture.Infrastructure.AI.Language
{
    public class MLLanguageDetector : ILanguageDetector
    {
        public MLLanguageDetector()
        {
        }

        public async Task<string> DetectLanguage(string text)
        {
           return await Task.FromResult("English");
        }

        
    }
}
