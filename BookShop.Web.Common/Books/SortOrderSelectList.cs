using System.Collections.Generic;
using System.Web.Mvc;

namespace BookShop.Web.Common.Books
{
    /// <summary>
    /// select lista do wyboru sortowania
    /// </summary>
    public static class SortOrderSelectList
    {
        public static SelectList SortOrder => new SelectList(new List<string> { "Sortuj", "Tytuł A-Z", "Tytuł Z-A", "Cena rosnąco", "Cena malejąco" }, "Sortuj");
    }
}