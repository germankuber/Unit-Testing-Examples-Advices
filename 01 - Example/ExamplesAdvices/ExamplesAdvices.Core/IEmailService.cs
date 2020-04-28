namespace ExamplesAdvices.Core
{
    public interface IEmailService
    {
        void Send(string email, string body);
    }
}