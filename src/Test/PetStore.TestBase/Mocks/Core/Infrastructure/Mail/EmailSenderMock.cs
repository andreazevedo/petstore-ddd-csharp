using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using PetStore.Core.Infrastructure.Mail;

namespace PetStore.TestBase.Mocks.Core.Infrastructure.Mail
{
    public class EmailSenderMock : IEmailSender
    {
        #region Properties

        public int SendEmailCallCount { get; private set; }

        #endregion

        public void SendEmail(MailMessage mailMessage)
        {
            SendEmailCallCount++;
        }

        public void SendEmail(string from, string recipients, string subject, string body)
        {
            SendEmailCallCount++;
        }
    }
}
