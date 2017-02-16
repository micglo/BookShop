namespace BookShop.Models.ViewModels.BookReview
{
    /// <summary>
    /// Klasa reprezentująca model recenzji o książce
    /// </summary>
    public class AddBookReviewViewModel
    {
        public Data.BookReview BookReview { get; set; }
        public string ReturnUrl { get; set; }
    }
}