namespace BookShop.Models.ViewModels.Books
{
    /// <summary>
    /// Model reprezentujący odpowiedź po akcjach create i update służący do przekekierownaia na właściwy URL
    /// </summary>
    public class BookPostResponseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MainCategoryName { get; set; }
        public string SubMainCategoryName { get; set; }
    }
}