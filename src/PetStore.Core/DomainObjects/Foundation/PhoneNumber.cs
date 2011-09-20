namespace PetStore.Core.DomainObjects.Foundation
{
    /// <summary>
    /// Phone Number entity
    /// </summary>
    public class PhoneNumber
    {
        #region Public Properties

        /// <summary>
        /// Phone number Id
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Phone number type
        /// </summary>
        public virtual PhoneNumberType Type { get; set; }

        /// <summary>
        /// Phone number country code
        /// </summary>
        public virtual string CountryCode { get; set; }

        /// <summary>
        /// Phone number area code
        /// </summary>
        public virtual string AreaCode { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public virtual string Number { get; set; }

        /// <summary>
        /// Phone number contact name
        /// </summary>
        public virtual string ContactName { get; set; }

        #endregion
    }
}
