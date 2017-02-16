using System.Collections.Generic;
using BookShop.Data.Common;

namespace BookShop.Data
{
    /// <summary>
    /// Klasa przedstawiająca podkategorie dla głównych kategorii
    /// </summary>
    public class SubMainCategory : Entity<int>
    {
        /// <summary>
        /// Używane w URL
        /// </summary>
        public string Name { get; set; }
        public string NameForDisplay { get; set; }       
        public int MainCategoryId { get; set; }

        public virtual MainCategory MainCategory { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}