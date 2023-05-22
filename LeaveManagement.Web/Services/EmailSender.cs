using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace LeaveManagement.Web.Services
{
    public class EmailSender : IEmailSender
    {
        private string _smtpServer;
        private int _smtpPort;
        private string _fromEmailAddress;

        public EmailSender(string smtpServer, int smtpPort, string fromEmailAddress)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _fromEmailAddress = fromEmailAddress;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Créer un Email
            var message = new MailMessage
            {
                From = new MailAddress(_fromEmailAddress),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            // On peut ajouter un ou plusieurs destinataires (= copier/coller la ligne ci-dessous autant de fois que de destinataires)
            message.To.Add(new MailAddress(email));

            // Initialiser un client smtp:
            using (var client = new SmtpClient(_smtpServer, _smtpPort))
            {
                client.Send(message);
            }

            return Task.CompletedTask;
        }
    }
}
