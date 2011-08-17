namespace PetStore.Core.DomainObjects.Foundation
{
    /// <summary>
    /// Product entity
    /// </summary>
    public class Product
    {
        #region Public Properties

        /// <summary>
        /// Product ID
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Product category
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Product image path
        /// </summary>
        public virtual string ImagePath { get; set; }

        #endregion
    }
}
