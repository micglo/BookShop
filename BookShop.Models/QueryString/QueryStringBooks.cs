namespace BookShop.Models.QueryString
{
    /// <summary>
    /// Klasa reprezentująca model zapytań URL dla głównych kategorii i ich podkategorii oraz najbliższych kategorii książek
    /// </summary>
    public class QueryStringBooks : QueryStringBase
    {
        public string MainCategory { get; set; }
        public string SubMainCategory { get; set; }
        public string BookCategory { get; set; } = null;
    }
}