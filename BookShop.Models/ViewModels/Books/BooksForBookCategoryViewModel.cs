using System.Collections.Generic;
using BookShop.Data;

namespace BookShop.Models.ViewModels.Books
{
    public class BooksForBookCategoryViewModel : BooksBase
    {
        public IEnumerable<BookCategory> BookCategories { get; set; }
        public BookCategory CurrentBookCategory { get; set; }
    }
}