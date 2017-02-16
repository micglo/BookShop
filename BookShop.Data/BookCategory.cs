using System.Collections.Generic;
using BookShop.Data.Common;

namespace BookShop.Data
{
    /// <summary>
    /// Klasa przedstawiająca najbliższe kategorie książki
    /// </summary>
    public class BookCategory : Entity<int>
    {
        /// <summary>
        /// Używane w URL
        /// </summary>
        public string Name { get; set; }
        public string NameForDisplay { get; set; }
        public int SubMainCategoryId { get; set; }

        public virtual SubMainCategory SubMainCategory { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}