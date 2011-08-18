using PetStore.Core.DomainObjects.Security;

namespace PetStore.Core.DomainObjects.Foundation
{
    /// <summary>
    /// Cart item entity
    /// </summary>
    public class CartItem
    {
        #region Public Properties

        /// <summary>
        /// Cart item ID
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// User who added the item
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Product added
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
        /// Item subTotal
        /// </summary>
        public virtual decimal SubTotal
        {
            get
            {
                return Quantity * Price;
            }
        }



        #endregion
    }
}
