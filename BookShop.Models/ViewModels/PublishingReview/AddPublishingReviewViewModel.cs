namespace BookShop.Models.ViewModels.PublishingReview
{
    /// <summary>
    /// Klasa reprezentująca model recenzji o wydawnictwie
    /// </summary>
    public class AddPublishingReviewViewModel
    {
        public Data.PublishingReview PublishingReview { get; set; }
        public string ReturnUrl { get; set; }
    }
}