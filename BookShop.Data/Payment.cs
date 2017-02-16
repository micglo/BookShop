using System.Collections.Generic;
using BookShop.Data.Common;

namespace BookShop.Data
{
    /// <summary>
    /// Klasa przechowująca dane o zapłacie
    /// </summary>
    public class Payment : Entity<int>
    {
        public string PaymentType { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}