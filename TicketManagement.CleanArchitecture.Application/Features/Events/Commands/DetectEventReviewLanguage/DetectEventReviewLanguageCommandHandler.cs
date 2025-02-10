using MediatR;
using TicketManagement.CleanArchitecture.Application.Contracts.Infrastructure;

namespace TicketManagement.CleanArchitecture.Application.Features.Events.Commands.DetectEventReviewLanguage
{
    public class DetectEventReviewLanguageCommandHandler : IRequestHandler<DetectEventReviewLanguageCommand, string>
    {
        private readonly ILanguageDetector _languageDetector;

        public DetectEventReviewLanguageCommandHandler(ILanguageDetector languageDetector)
        {
            _languageDetector = languageDetector;
        }

        public async Task<string> Handle(DetectEventReviewLanguageCommand request, CancellationToken cancellationToken)
        {
            return await _languageDetector.DetectLanguage(request.Review);
        }
    }
}
