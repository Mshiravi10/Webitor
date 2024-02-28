using FluentEmail.Core;
using FluentEmail.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Moq;
using Webitor.Utility;

namespace Webitor.Tests;

public class HttpStatusEmailMiddlewareTests
{
    [Fact]
    public async Task Middleware_SendsEmail_WhenStatusCodeMatches()
    {
        var emailSettings = new EmailSettings
        {
            FromEmail = "test@example.com",
            ToEmail = "mohammadazrael86@gmail.com",
            DisplayName = "Test Sender",
            SmtpServer = "sandbox.smtp.mailtrap.io",
            Port = 2525,
            Username = "11742271fb89d6",
            Password = "7a245bae947a8a",
            UseSSL = true,
            StatusCodesToNotify = new List<int> { 404 }
        };

        var optionsMock = new Mock<IOptions<EmailSettings>>();
        optionsMock.Setup(opt => opt.Value).Returns(emailSettings);

        var emailServiceMock = new Mock<IEmailService>();
        emailServiceMock.Setup(x => x.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                        .Returns(Task.CompletedTask);

        var middleware = new HttpStatusEmailMiddleware(next: (context) => Task.CompletedTask, optionsMock.Object, emailServiceMock.Object);


        var context = new DefaultHttpContext();
        context.Response.StatusCode = 404;
        context.Response.Body = new MemoryStream(); 

        // Act
        await middleware.Invoke(context);


        // Assert
        emailServiceMock.Verify(service => service.SendEmailAsync(emailSettings.ToEmail, It.IsAny<string>(), It.IsAny<string>()), Times.Once());

    }
}