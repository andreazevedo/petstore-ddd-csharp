namespace PetStore.Core.DomainObjects.Foundation
{
    /// <summary>
    /// Entidade que representa uma categoria de produtos
    /// </summary>
    public class Category
    {
        #region Public Properties

        /// <summary>
        /// Id da categoria
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da Categoria
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição da categoria
        /// </summary>
        public string Description { get; set; }

        #endregion
    }
}
