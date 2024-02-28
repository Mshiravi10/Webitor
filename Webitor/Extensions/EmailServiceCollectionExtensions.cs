using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webitor.Utility;

namespace Webitor.Extensions
{
    public static class EmailServiceCollectionExtensions
    {
        public static IServiceCollection AddEmailServices(this IServiceCollection services, IConfiguration configuration)
        {
            var emailSettings = new EmailSettings();
            configuration.GetSection("EmailSettings").Bind(emailSettings);

            services.AddSingleton(emailSettings);

            services
                .AddFluentEmail(emailSettings.FromEmail, emailSettings.DisplayName)
                .AddSmtpSender(emailSettings.SmtpServer, emailSettings.Port, emailSettings.Username, emailSettings.Password);

            return services;
        }
    }
}
