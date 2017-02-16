namespace BookShop.Models.QueryString
{
    /// <summary>
    /// Klasa reprezentująca model wykorzystywany dla zapytań użytych w wyszukiwarce
    /// </summary>
    public class QueryStringSearch : QueryStringBase
    {
        public string SearchString { get; set; } = null;
        public string SearchOption { get; set; } = "Wszędzie";
    }
}