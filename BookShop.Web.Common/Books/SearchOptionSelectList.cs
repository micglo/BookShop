using System.Collections.Generic;
using System.Web.Mvc;

namespace BookShop.Web.Common.Books
{
    /// <summary>
    /// Select lista do wyboru gdzie szukać
    /// </summary>
    public static class SearchOptionSelectList
    {
        public static SelectList SearchOption => new SelectList(new List<string>
        {
            "Wszędzie", "Książki", "Podręczniki", "Ebooki", "Audiobooki", "Komiksy", "Bestsellery", "Autorzy", "Wydawnictwa"
        }, 
            "Wszędzie");
    }
}