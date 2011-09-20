using System.Collections.Generic;

namespace PetStore.Core.DomainObjects.Foundation
{
    /// <summary>
    /// Supplier entity
    /// </summary>
    public class Supplier
    {
        #region Public Properties

        /// <summary>
        /// Supplier Id
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Supplier Name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Supplier Address
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Supplier phone numbers
        /// </summary>
        public virtual IList<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Indicates if the supplier is active
        /// </summary>
        public virtual bool IsActive { get; set; }

        #endregion
    }
}
