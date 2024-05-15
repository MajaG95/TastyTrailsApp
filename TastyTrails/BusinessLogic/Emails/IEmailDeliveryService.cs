using System.Net.Mail;

namespace BusinessLogic.Emails
{
    public interface IEmailDeliveryService
    {
        void SendEmail(MailMessage emailMessage);
    }
}
