using System;
using System.Collections.Generic;
using BookShop.Data.Common;

namespace BookShop.Data
{
    /// <summary>
    /// Klasa przedstawiająca transakcje użytkownika
    /// </summary>
    public class Transaction : Entity<int>
    {
        public TransactionStatus TransactionStatus { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string UserId { get; set; }
        public int PaymentId { get; set; }
        public int DeliveryId { get; set; }
        public int DeliveryAddressId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Delivery Delivery { get; set; }
        public virtual DeliveryAddress DeliveryAddress { get; set; }
        public virtual ICollection<TransactionBookQuantity> TransactionBookQuantities { get; set; }
    }
}