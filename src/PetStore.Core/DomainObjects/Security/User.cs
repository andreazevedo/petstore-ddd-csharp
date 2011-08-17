namespace PetStore.Core.DomainObjects.Security
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User
    {
        #region Public Properties

        /// <summary>
        /// User name (FullName)
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// User name (login)
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Indicates whether the user is not registered yet
        /// </summary>
        public virtual bool IsAnonymous { get; set; }

        
        // TODO - Analyze LastActivityDate and LastUpdatedDate on Microsoft PetShop


        #endregion
    }
}
