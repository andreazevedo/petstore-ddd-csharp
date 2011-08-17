namespace PetStore.Core.DomainObjects.Foundation
{
    /// <summary>
    /// Entidade que representa um produto
    /// </summary>
    public class Product
    {
        #region Public Properties

        /// <summary>
        /// Id único do produto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Categoria do produto
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Nome do produto
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição do produto
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Caminho da imagem do produto
        /// </summary>
        public string ImagePath { get; set; }

        #endregion
    }
}
