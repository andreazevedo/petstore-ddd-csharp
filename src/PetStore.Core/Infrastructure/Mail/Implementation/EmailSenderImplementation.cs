using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace PetStore.Core.Infrastructure.Mail.Implementation
{
    public class EmailSenderImplementation : IEmailSender
    {
        public void SendEmail(MailMessage mailMessage)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw new EmailSendException(ex);
            }
        }

        public void SendEmail(string from, string recipients, string subject, string body)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Send(from, recipients, subject, body);
                }
            }
            catch (Exception ex)
            {
                throw new EmailSendException(ex);
            }
        }
    }
}
