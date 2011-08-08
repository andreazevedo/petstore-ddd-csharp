using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetStore.Core.Infrastructure.InversionOfControl;

namespace PetStore.Core.Infrastructure.Mail
{
    /// <summary>
    /// Send e-mails
    /// </summary>
    public static class EmailSender
    {
        #region Public Members

        #endregion

        #region Private Methods

        private static IEmailSender InternalEmailSender
        {
            get
            {
                return IoC.Resolve<IEmailSender>();
            }
        }

        #endregion
    }
}
