using System.Collections.Generic;

namespace BookShop.Models.ViewModels
{
    public class InfoViewModel
    {
        public string Message { get; set; } = "";
        public List<string> Errors { get; set; } = new List<string>();
    }
}