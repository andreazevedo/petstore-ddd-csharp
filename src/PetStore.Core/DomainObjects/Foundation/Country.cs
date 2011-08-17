namespace PetStore.Core.DomainObjects.Foundation
{
    /// <summary>
    /// Country entity
    /// </summary>
    public class Country
    {
        #region Public Properties

        /// <summary>
        /// Country ID
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Country code (acronym) defined on (ISO 3166-1 alfa-2)
        /// </summary>
        public virtual string Code { get; set; }

        #endregion
    }
}
