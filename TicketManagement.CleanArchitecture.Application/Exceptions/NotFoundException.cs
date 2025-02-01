namespace TicketManagement.CleanArchitecture.Application.Exceptions
{
    internal class NotFoundException : Exception
    {
        public NotFoundException(string name, string key) : base($"{name} ({key}) is not found")
        {
        }
    }
}
