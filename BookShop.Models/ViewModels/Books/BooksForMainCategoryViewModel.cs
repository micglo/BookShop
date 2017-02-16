using System.Collections.Generic;
using BookShop.Data;

namespace BookShop.Models.ViewModels.Books
{
    public class BooksForMainCategoryViewModel
    {
        public IEnumerable<SubMainCategory> SubMainCategories { get; set; }

        /// <summary>
        /// 5 bestsellerów z każdej podkategorii dla głównej kategorii
        /// </summary>
        public IEnumerable<Book> TopFiveBooksForEachSubMainCategory { get; set; }
        public MainCategory CurrentMainCategory { get; set; }
    }
}