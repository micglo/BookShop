using System.ComponentModel.DataAnnotations;

namespace BookShop.Models.ViewModels.Menu
{
    /// <summary>
    /// binding model dla wyszukiwarki
    /// </summary>
    public class MenuSearchViewModel
    {
        [Required]
        public string SearchString { get; set; }
    }
}