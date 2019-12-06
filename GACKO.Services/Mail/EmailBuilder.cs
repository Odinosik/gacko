using GACKO.Shared.Models.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace GACKO.Services.Mail
{
    public class EmailBuilder
    {
        public static EmailDefinition buildEmail(string email, string body)
        {

            List<EmailAddress> emailAddresses = new List<EmailAddress>();
            emailAddresses.Add(new EmailAddress()
            {
                Name = "Tomek Tomkowski",
                Address = email
            });

            EmailDefinition emailDefinition = new EmailDefinition()
            {
                To = emailAddresses,
                Subject = "Weryfikacja",
                Body = body
            };

            return emailDefinition;
        }
    }
}
