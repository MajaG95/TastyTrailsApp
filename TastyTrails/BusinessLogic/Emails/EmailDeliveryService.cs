using System.Net.Mail;

namespace BusinessLogic.Emails
{
    public class EmailDeliveryService : IEmailDeliveryService
    {
        private readonly ISmtpClientService _smtpClientService;

        public EmailDeliveryService(ISmtpClientService smtpClientService)
        {
            _smtpClientService = smtpClientService;
        }

        public void SendEmail(MailMessage emailMessage)
        {
            try
            {
                using (var client = OpenSmtpConnection())
                {
                    client.Send(emailMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error sending E-mail", ex);
            }
        }

        private SmtpClient OpenSmtpConnection()
        {
            return _smtpClientService.GetSmtpClient();
        }
    }
}
