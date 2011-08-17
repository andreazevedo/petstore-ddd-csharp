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
        public virtual int Id { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Category description
        /// </summary>
        public virtual string Description { get; set; }

        #endregion
    }
}
