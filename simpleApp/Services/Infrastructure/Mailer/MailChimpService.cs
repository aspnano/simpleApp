// --using statements from Mailchimp SDK

namespace simpleApp.Services.Infrastructure.Mailer
{
    public class MailChimpService : IMailerService
    {
        // send method (required by interface)
        public bool SendEmail(string message, string subject)
        {
           
            // --
            // -- code specific to MailChimp
            // --

            return true;
        }
    }
}
