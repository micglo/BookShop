using System.Collections.Generic;
using BookShop.Data;

namespace BookShop.Models.ViewModels.Transaction
{
    /// <summary>
    /// Model przedstawiający szczegółowe dane transakcji
    /// </summary>
    public class TransactionDetailViewModel : MyTransactionsViewModel
    {
        public Delivery Delivery { get; set; }
        public Payment Payment { get; set; }
        public IEnumerable<TransactionBookQuantity> BookQuantities { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
    }
}