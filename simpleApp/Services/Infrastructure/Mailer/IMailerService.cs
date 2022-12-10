namespace simpleApp.Services.Infrastructure.Mailer
{
    public interface IMailerService
    {
        bool SendEmail(string message, string subject);
    }
}
