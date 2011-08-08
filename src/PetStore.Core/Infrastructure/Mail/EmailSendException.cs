using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetStore.Resources.Infrastructure;

namespace PetStore.Core.Infrastructure.Mail
{
    /// <summary>
    /// Exception on sending e-mail
    /// </summary>
    public class EmailSendException : DomainException
    {
        #region Constructors

        public EmailSendException()
            : base(MailResources.SendEmailExceptionDefaultMessage)
        { }

        public EmailSendException(Exception innerException)
            : base(MailResources.SendEmailExceptionDefaultMessage, innerException)
        { }

        #endregion
    }
}
