namespace BookShop.Models.ViewModels.AuthorReview
{
    /// <summary>
    /// Klasa reprezentująca model recenzji o autorze
    /// </summary>
    public class AddAuthorReviewViewModel
    {
        public Data.AuthorReview AuthorReview { get; set; }
        public string ReturnUrl { get; set; }
    }
}