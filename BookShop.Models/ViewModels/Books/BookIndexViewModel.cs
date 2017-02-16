using System.Collections.Generic;
using BookShop.Data;

namespace BookShop.Models.ViewModels.Books
{
    /// <summary>
    /// Model reprezentujacy książkę
    /// </summary>
    public class BookIndexViewModel
    {
        public string MainCategoryName { get; set; }
        public string SubMainCategoryName { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public string TitleForDisplay { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public bool? Bestseller { get; set; }
        public string Cover { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
    }
}