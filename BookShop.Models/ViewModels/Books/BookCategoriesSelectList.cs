using System.Collections.Generic;

namespace BookShop.Models.ViewModels.Books
{
    /// <summary>
    /// Klasa reprezentująca model zwracany do select listy, do wyboru kategorii
    /// </summary>
    public class BookCategoriesSelectList
    {
        public string Text { get; set; }
        public IEnumerable<SelectListViewModel> Children { get; set; }
    }
}