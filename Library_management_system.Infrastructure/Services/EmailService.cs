using Library_management_system.Application.Events.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly EmailSettings _emailSettings;
        public EmailService(SmtpClient smtpClient, IOptions<EmailSettings> emailSettings)
        {
            _smtpClient = smtpClient;
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string from, string subject, string body)
        {
            var fromAddress = new MailAddress(_emailSettings.FromEmail, _emailSettings.FromName);
            var toAddress = new MailAddress(from);

            // Crear un nuevo mensaje para cada envío
            using (var mailMessage = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
                try
            {
                await _smtpClient.SendMailAsync(mailMessage);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
