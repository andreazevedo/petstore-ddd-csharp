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
        /// Address street name
        /// </summary>
        public virtual string Street { get; set; }

        /// <summary>
        /// Address number
        /// </summary>
        public virtual string Number { get; set; }

        /// <summary>
        /// Address district/neighborhood
        /// </summary>
        public virtual string District { get; set; }
        
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
