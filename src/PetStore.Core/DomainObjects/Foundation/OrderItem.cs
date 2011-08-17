namespace PetStore.Core.DomainObjects.Foundation
{
    /// <summary>
    /// Order item entity
    /// </summary>
    public class OrderItem
    {
        #region Public Properties

        /// <summary>
        /// Order item ID
        /// </summary>
        public virtual int Id { get; set; }
        
        /// <summary>
        /// Order that contains this item
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Product quantity
        /// </summary>
        public virtual int Quantity { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        public virtual decimal Price { get; set; }

        /// <summary>
        /// Order item subtotal
        /// </summary>
        public virtual decimal SubTotal
        {
            get
            {
                return Quantity*Price;
            }
        }

        #endregion
    }
}
