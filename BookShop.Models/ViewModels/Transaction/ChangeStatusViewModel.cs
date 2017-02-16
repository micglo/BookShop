using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookShop.Models.ViewModels.Transaction
{
    public class ChangeStatusViewModel
    {
        public int TransactionId { get; set; }

        [Display(Name = "Status")]
        public SelectList TransactionStatusSelectList { get; set; }
    }
}