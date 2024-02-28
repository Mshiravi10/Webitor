# HTTP Status Email Notifier

This library provides an ASP.NET Core middleware that sends email notifications when HTTP responses with specific status codes are generated. It's highly configurable through `appsettings.json`, allowing easy integration and customization.

## Features

- **Flexible Configuration**: Configure SMTP settings and targeted HTTP status codes directly from `appsettings.json`.
- **Easy Integration**: Simple setup with extension methods for IServiceCollection and IApplicationBuilder.
- **Testability**: Includes both unit tests using xUnit and Moq, and integration tests for verifying email sending functionality.

## Getting Started

Follow these steps to integrate the HTTP Status Email Notifier into your ASP.NET Core project.

### Step 1: Configuration

Add your email settings to the `appsettings.json` file:

```json
{
  "EmailSettings": {
    "FromEmail": "your-email@example.com",
    "ToEmail": "recipient@example.com",
    "DisplayName": "Your Display Name",
    "SmtpServer": "smtp.example.com",
    "Port": 587,
    "Username": "your-username",
    "Password": "your-password",
    "UseSSL": true,
    "StatusCodesToNotify": [404, 500]
  }
}
```
### Step 2: Service Registration
In your Startup.cs or Program.cs, call AddEmailServices to register email services and middleware.

In to the (Program.cs):

```

var builder = WebApplication.CreateBuilder(args);

// Add email services
builder.Services.AddEmailServices(builder.Configuration);

var app = builder.Build();

// Use HTTP Status Email Middleware
app.UseHttpStatusEmailMiddleware();

app.Run();

```
### Step 3: Enjoy
That's it! Now, whenever your application generates an HTTP response with one of the specified status codes, an email notification will be sent.

## Testing
The library includes both unit and integration tests:

Unit Tests: Implemented using xUnit and Moq to test the functionality without sending real emails.
Integration Tests: Tests the email sending capability in a real scenario, ensuring that emails are correctly dispatched when specified HTTP status codes are encountered.
## Contribution
Contributions are welcome! If you have suggestions or want to improve this library, please feel free to create issues or submit pull requests on GitHub.