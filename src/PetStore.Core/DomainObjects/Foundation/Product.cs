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
        public int Id { get; set; }

        /// <summary>
        /// Product category
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Product image path
        /// </summary>
        public string ImagePath { get; set; }

        #endregion
    }
}
