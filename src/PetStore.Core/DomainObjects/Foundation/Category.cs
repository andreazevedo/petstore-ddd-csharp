namespace PetStore.Core.DomainObjects.Foundation
{
    /// <summary>
    /// Category entity
    /// </summary>
    public class Category
    {
        #region Public Properties

        /// <summary>
        /// Category ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Category description
        /// </summary>
        public string Description { get; set; }

        #endregion
    }
}
