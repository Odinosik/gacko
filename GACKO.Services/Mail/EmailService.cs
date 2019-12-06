using GACKO.Shared.Models.Email;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using MailKit.Net.Smtp;
using System.Text;
using GACKO.Shared.Models.Expense;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace GACKO.Services.Mail
{
    public class EmailService : IEmailService
    {
        private readonly EmailServiceOptions _options;
        public EmailService(IOptions<EmailServiceOptions> emailServiceOptions)
        {
            _options = emailServiceOptions.Value;
        }
        public async Task SendMailAsync(CancellationToken cancellationToken, params EmailDefinition[] emailDefinitions)
        {
            if (emailDefinitions == null)
            {
                throw new ArgumentNullException(nameof(emailDefinitions));
            }
            var mimeMessages = new MimeMessage[emailDefinitions.Length];
            for (var i = 0; i < emailDefinitions.Length; i++)
            {
                var emailDefinition = emailDefinitions[i];
                var mimeMessage = new MimeMessage();
                foreach (var emailAdr in emailDefinition.To)
                {
                    mimeMessage.To.Add(new MailboxAddress(emailAdr.Name, emailAdr.Address));
                }
                mimeMessage.Subject = emailDefinition.Subject;
                var builder = new BodyBuilder();
                if (!string.IsNullOrWhiteSpace(emailDefinition.Body))
                {
                    builder.TextBody = emailDefinition.Body;
                }
                if (!string.IsNullOrWhiteSpace(emailDefinition.HtmlBody))
                {
                    builder.HtmlBody = emailDefinition.HtmlBody;
                }
                mimeMessage.Body = builder.ToMessageBody();
                mimeMessage.From.Add(new MailboxAddress(_options.From, _options.FromAddress));
                mimeMessages[i] = mimeMessage;
            }
            await SendEmailAsyncInner(cancellationToken, mimeMessages);
        }

        private async Task SendEmailAsyncInner(CancellationToken cancellationToken,
           IEnumerable<MimeMessage> mimeMessages)
        {
            if (!string.IsNullOrWhiteSpace(_options.Server))
            {
                try
                {
                    using (var smtpClient = new SmtpClient())
                    {
                        if (_options.SecureSocketOptions == SecureSocketOptions.None)
                        {
                            await smtpClient.ConnectAsync(_options.Server, _options.Port, false, cancellationToken);
                        }
                        else
                        {
                            smtpClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                            await smtpClient.ConnectAsync(_options.Server, 25, _options.SecureSocketOptions, cancellationToken);
                        }
                        if (!string.IsNullOrWhiteSpace(_options.UserName))
                        {
                            await smtpClient.AuthenticateAsync(_options.UserName, _options.Password, cancellationToken);
                        }
                        foreach (var mimeMessage in mimeMessages)
                        {
                            await smtpClient.SendAsync(mimeMessage, cancellationToken);
                        }
                        await smtpClient.DisconnectAsync(true, cancellationToken);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                throw new Exception("Email service not configured");
            }
        }
        public List<string> CreateBody(List<ExpenseForm> expenses)
        {
            return expenses.Select(_ => _.Name = _.Amount.ToString()).ToList();
        }
    }
}
