namespace BookShop.Models.QueryString
{
    /// <summary>
    /// Klasa reprezentująca podstawowy model wykorzystywany do zapytań URL dla książek
    /// </summary>
    public class QueryStringBase
    {
        public int Page { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 3;
        public string SortOrder { get; set; } = "Sortuj";
    }
}