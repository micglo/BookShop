namespace BookShop.Models.ViewModels.Transaction
{
    /// <summary>
    /// Model reprezentujący transakcje dla widoku w tabeli
    /// </summary>
    public class MyTransactionsViewModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public string TransactionAmount { get; set; }
    }
}