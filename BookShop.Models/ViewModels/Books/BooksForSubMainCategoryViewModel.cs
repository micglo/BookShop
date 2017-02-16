using System.Collections.Generic;
using BookShop.Data;

namespace BookShop.Models.ViewModels.Books
{
    public class BooksForSubMainCategoryViewModel : BooksBase
    {
        public IEnumerable<BookCategory> BookCategories { get; set; }
        public IEnumerable<BookCategory> BookCategoriesWithBooks { get; set; }

        /// <summary>
        /// % bestselerów z każdej kategorii najbliższej dla książki
        /// </summary>
        public IEnumerable<Book> TopFiveBooksForEachBookCategory { get; set; }
    }
}