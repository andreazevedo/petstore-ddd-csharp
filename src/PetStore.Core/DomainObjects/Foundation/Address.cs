namespace PetStore.Core.DomainObjects.Foundation
{
    /// <summary>
    /// Address entity
    /// http://en.wikipedia.org/wiki/Address_(geography)
    /// </summary>
    public class Address
    {
        #region Public Properties

        /// <summary>
        /// Address ID
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// First address line
        /// </summary>
        public virtual string FirstLine { get; set; }

        /// <summary>
        /// Second address line
        /// </summary>
        public virtual string SecondLine { get; set; }

        /// <summary>
        /// Address city/town/locality
        /// </summary>
        public virtual string City { get; set; }

        /// <summary>
        /// Address State/Province/Region
        /// </summary>
        public virtual string State { get; set; }

        /// <summary>
        /// Address country
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Address ZIP/Postal Code
        /// </summary>
        public virtual string PostalCode { get; set; }

        /// <summary>
        /// Address additional information
        /// </summary>
        public virtual string AdditionalInformation { get; set; }

        #endregion
    }
}
