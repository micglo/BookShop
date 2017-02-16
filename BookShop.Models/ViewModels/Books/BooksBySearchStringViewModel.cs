namespace BookShop.Models.ViewModels.Books
{
    /// <summary>
    /// Zwracany model dla akcji wyszukiwania książek
    /// </summary>
    public class BooksBySearchStringViewModel : BooksBase
    {
        public string CurrentSearchString { get; set; }
        public string CurrentSearchOption { get; set; }
    }
}