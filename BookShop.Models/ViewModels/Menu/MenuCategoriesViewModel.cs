using System.Collections.Generic;

namespace BookShop.Models.ViewModels.Menu
{
    /// <summary>
    /// Model do wyświetlania menu kategorii
    /// </summary>
    public class MenuCategoriesViewModel
    {
        public IEnumerable<Data.MainCategory> MainCategories { get; set; }
        public IEnumerable<Data.SubMainCategory> SubMainCategories { get; set; }
    }
}