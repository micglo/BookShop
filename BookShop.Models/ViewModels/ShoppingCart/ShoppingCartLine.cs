using BookShop.Data;

namespace BookShop.Models.ViewModels.ShoppingCart
{
    /// <summary>
    /// Model reprezentujacy jedna linie koszyka, Produkt i jego ilość, koszyk może składać się z wielu linii
    /// </summary>
    public class ShoppingCartLine
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }

}