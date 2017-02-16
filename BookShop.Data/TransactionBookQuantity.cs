using BookShop.Data.Common;

namespace BookShop.Data
{
    /// <summary>
    /// Klasa przedstawiająca powiązanie pomiedzy zakupionym produktem, a jego ilością
    /// </summary>
    public class TransactionBookQuantity : Entity<int>
    {
        public int BookId { get; set; }
        public decimal BookPrice { get; set; }
        public int Quantity { get; set; }
        public int TransactionId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}