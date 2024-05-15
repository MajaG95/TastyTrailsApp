using System.Net.Mail;

namespace BusinessLogic.Emails
{
    public class SmtpClientService : ISmtpClientService
    {
        private readonly string _directory = @"D:\";
        public SmtpClient GetSmtpClient()
        {
            Directory.CreateDirectory(_directory);
            var client = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = _directory
            };
            return client;
        }
    }
}
