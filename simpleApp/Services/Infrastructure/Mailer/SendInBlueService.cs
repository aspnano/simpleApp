// --using statements from SendInBlue SDK

namespace simpleApp.Services.Infrastructure.Mailer
{
    public class SendInBlueService : IMailerService
    {
        // send method (required by interface)
        public bool SendEmail(string message, string subject)
        {
            // --
            // -- code specific to SendInBlue
            // --

            return true;
        }
    }
}
