using System;

namespace PetStore.Core.DomainObjects.Payment
{
    public class CreditCard
    {
        #region Public Properties

        /// <summary>
        /// Credit card number
        /// </summary>
        public virtual string Number { get; set; }

        /// <summary>
        /// Credit card expiration date
        /// </summary>
        public virtual DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Credit card association (Visa, Mastercard, etc.)
        /// </summary>
        public virtual CreditCardAssociation Association { get; set; }

        #endregion
    }
}
