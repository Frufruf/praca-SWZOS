using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog;
using System;
using System.Threading.Tasks;

namespace SWZOS.Services
{
    //public class EmailSender : IEmailSender
    //{
    //    public AuthMessageSenderOptions Options { get; }

    //    public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
    //    {
    //        Options = optionsAccessor.Value;
    //    }

        

    //    //public async Task SendEmailAsync(string toEmail, string subject, string message)
    //    //{
    //    //    if (string.IsNullOrEmpty(Options.SendGridKey))
    //    //    {
    //    //        throw new Exception("Null SendGridKey");
    //    //    }
    //    //    await Execute(Options.SendGridKey, subject, message, toEmail);
    //    //}

    //    //public async Task Execute(string apiKey, string subject, string message, string toEmail)
    //    //{
    //    //    var client = new SendGridClient(apiKey);
    //    //    var msg = new SendGridMessage()
    //    //    {
    //    //        From = new EmailAddress(""),
    //    //        Subject = subject,
    //    //        PlainTextContent = message,
    //    //        HtmlContent = message
    //    //    };

    //    //    msg.AddTo(new EmailAddress(toEmail));
    //    //    msg.SetClickTracking(false, false);

    //    //    var response = await client.SendEmailAsync(msg);

    //    //    if (!response.IsSuccessStatusCode)
    //    //    {
    //    //        Log.Logger.Error("Przy wysyłce maila pod adres: " + toEmail + " wystąpił błąd");
    //    //    }
    //    //}
    //}
}
