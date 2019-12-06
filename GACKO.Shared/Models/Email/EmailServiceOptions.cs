using MailKit.Security;

namespace GACKO.Shared.Models.Email
{
    public class EmailServiceOptions
    {
        public string Server { get; set; }
        public string FromAddress { get; set; }
        public string From { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public SecureSocketOptions SecureSocketOptions { get; set; }
    }
}

