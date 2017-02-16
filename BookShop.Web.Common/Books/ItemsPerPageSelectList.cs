using System.Collections.Generic;
using System.Web.Mvc;

namespace BookShop.Web.Common.Books
{
    /// <summary>
    /// Select lista z ilością itemów do wyświetlenia na stronie
    /// </summary>
    public static class ItemsPerPageSelectList
    {
        public static SelectList ItemsPerPage => new SelectList(new List<int> { 1, 2, 3, 4, 5 }, 3);
    }
}