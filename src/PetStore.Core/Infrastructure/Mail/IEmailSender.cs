using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace PetStore.Core.Infrastructure.Mail
{
    /// <summary>
    /// Send e-mails
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends an e-mail.
        /// </summary>
        /// <param name="mailMessage">Mail message.</param>
        void SendEmail(MailMessage mailMessage);

        /// <summary>
        /// Sends an e-mail.
        /// </summary>
        /// <param name="from">From</param>
        /// <param name="recipients">to (if more than one, separete by semicolon)</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        void SendEmail(string from, string recipients, string subject, string body);
    }
}
