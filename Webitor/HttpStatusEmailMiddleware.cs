using FluentEmail.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Webitor.Utility;

namespace Webitor
{
    public class HttpStatusEmailMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly EmailSettings _emailSettings;
        private readonly IEmailService _emailService; 

        public HttpStatusEmailMiddleware(RequestDelegate next, IOptions<EmailSettings> emailSettings, IEmailService emailService)
        {
            _next = next;
            _emailSettings = emailSettings.Value;
            _emailService = emailService;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (_emailSettings.StatusCodesToNotify.Contains(context.Response.StatusCode))
            {
                await _emailService.SendEmailAsync(
                    _emailSettings.ToEmail,
                    $"Alert: HTTP Status {context.Response.StatusCode}",
                    $"An HTTP request resulted in a {context.Response.StatusCode} response.");
            }
        }
    }

}
