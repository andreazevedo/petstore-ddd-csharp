namespace PetStore.Core.DomainObjects.Payment
{
    /// <summary>
    /// Credit card association entity
    /// </summary>
    public class CreditCardAssociation
    {
        #region Public Properties

        /// <summary>
        /// Credit card association ID
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Credit card association name (Visa, Mastercard, American Express, etc)
        /// </summary>
        public virtual string Name { get; set; }

        #endregion
    }
}
