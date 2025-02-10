namespace TicketManagement.CleanArchitecture.Application.Contracts.Infrastructure
{
    public interface ILanguageDetector
    {
        Task<string> DetectLanguage(string text);
    }
}
