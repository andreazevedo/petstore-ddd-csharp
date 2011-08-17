using System;
using System.Collections.Generic;
using PetStore.Core.DomainObjects.Payment;
using PetStore.Core.DomainObjects.Security;

namespace PetStore.Core.DomainObjects.Foundation
{
    /// <summary>
    /// Order entity
    /// </summary>
    public class Order
    {
        #region Public Properties

        /// <summary>
        /// Order ID
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Order user
        /// </summary>
        public virtual User User { get; set;}

        /// <summary>
        /// Credit card used to pay the order
        /// </summary>
        public virtual CreditCard CreditCard { get; set; }

        /// <summary>
        /// Order billing address
        /// </summary>
        public virtual Address BillingAddress { get; set; }

        /// <summary>
        /// Order shipping address
        /// </summary>
        public virtual Address ShippingAddress { get; set; }

        /// <summary>
        /// Order items
        /// </summary>
        public virtual IList<OrderItem> Items { get; set; }

        /// <summary>
        /// Order total
        /// </summary>
        public virtual decimal Total { get; set; }


        /// <summary>
        /// Credit card authorization number
        /// TODO - It must be on CreditCardPayment entity
        /// </summary>
        public virtual int? AuthorizationNumber { get; set; }

        /// <summary>
        /// Order creation date
        /// </summary>
        public virtual DateTime CreatedAt { get; set; }

        #endregion
    }
}
