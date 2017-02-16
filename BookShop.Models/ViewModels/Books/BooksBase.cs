using BookShop.Data;

namespace BookShop.Models.ViewModels.Books
{
    /// <summary>
    /// Podstawowy model dla akcji GET książki
    /// </summary>
    public class BooksBase
    {
        public MainCategory CurrentMainCategory { get; set; }
        public SubMainCategory CurrentSubMainCategory { get; set; }
        public PagedList.IPagedList<Book> Books { get; set; }
        public int CurrentItemsPerPage { get; set; }
        public string CurrentSortOrder { get; set; }
    }
}