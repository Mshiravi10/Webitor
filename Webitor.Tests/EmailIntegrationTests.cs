using FluentEmail.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webitor.Utility;

namespace Webitor.Tests
{
    public class EmailIntegrationTests
    {
        [Fact]
        public async Task SendEmail_UsingRealEmailService()
        {
            // Setup
            var services = new ServiceCollection();
            services.Configure<EmailSettings>(options =>
            {
                options.FromEmail = "test@example.com";
                options.ToEmail = "mohammadazrael86@gmail.com";
                options.SmtpServer = "sandbox.smtp.mailtrap.io";
                options.Port = 2525;
                options.Username = "11742271fb89d6";
                options.Password = "7a245bae947a8a";
                options.UseSSL = true;
            });

            services.AddTransient<IEmailService, EmailService>();
            var serviceProvider = services.BuildServiceProvider();

            var emailService = serviceProvider.GetService<IEmailService>();
            var emailSettings = serviceProvider.GetService<IOptions<EmailSettings>>().Value;

            // Act
            await emailService.SendEmailAsync(emailSettings.ToEmail, "Integration Test Email", "This is a test email from integration test.");


        }
    }
}
