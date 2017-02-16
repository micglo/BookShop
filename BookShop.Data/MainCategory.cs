using System.Collections.Generic;
using BookShop.Data.Common;

namespace BookShop.Data
{
    /// <summary>
    /// Klasa przedstawiająca główne kategorie
    /// </summary>
    public class MainCategory : Entity<int>
    {
        /// <summary>
        /// Używany w URL
        /// </summary>
        public string Name { get; set; }
        public string NameForDisplay { get; set; }
        public virtual ICollection<SubMainCategory> SubMainCategories { get; set; }
    }
}