using System.Net.Mail;

namespace BusinessLogic.Emails
{
    public interface ISmtpClientService
    {
        SmtpClient GetSmtpClient();
    }
}
