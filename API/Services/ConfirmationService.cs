using API.Factories;
using API.Interfaces;
using API.Models;
using Azure;
using Azure.Communication.Email;

namespace API.Services;

public class ConfirmationService(EmailClient client, IConfiguration config) : IConfirmationService
{
    private readonly EmailClient _client = client;
    private readonly string _senderAddress = config["ACS:SenderAddress"]!;

    public async Task SendConfirmationEmailAsync(ConfirmationRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email))
            throw new ArgumentException("Recipient email address is required.");

        var (subject, html) = EmailTemplateFactory.Create(request);

        var message = new EmailMessage(
            _senderAddress,
            new EmailRecipients([new(request.Email)]),
            new EmailContent(subject) { Html = html }
        );

        await _client.SendAsync(WaitUntil.Completed, message);
    }
}