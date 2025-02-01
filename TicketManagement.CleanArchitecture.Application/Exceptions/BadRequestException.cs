namespace TicketManagement.CleanArchitecture.Application.Exceptions
{
    internal class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
