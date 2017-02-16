using System.Collections.Generic;
using BookShop.Data.Common;

namespace BookShop.Data
{
    /// <summary>
    /// Klasa przedstawiająca forme i cene dostawy oferowanej przez sklep
    /// </summary>
    public class Delivery : Entity<int>
    {
        public string DeliveryType { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}