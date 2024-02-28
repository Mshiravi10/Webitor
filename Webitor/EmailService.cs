using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Webitor.Utility;

namespace Webitor
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSender _smtpSender;
        private readonly EmailSettings _emailSettings;


        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;

            _smtpSender = new SmtpSender(() => new SmtpClient(_emailSettings.SmtpServer)
            {
                EnableSsl = _emailSettings.UseSSL,
                Port = _emailSettings.Port,
                Credentials = new System.Net.NetworkCredential(_emailSettings.Username, _emailSettings.Password)
            });

            Email.DefaultSender = _smtpSender;
        }
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var email = Email
                .From(_emailSettings.FromEmail)
                .To(to)
                .Subject(subject)
                .Body(body);

            await email.SendAsync();
        }
    }
}
