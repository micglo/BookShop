using System.Data.Entity.ModelConfiguration;

namespace BookShop.Data.Sql.FluentApiConfig
{
    /// <summary>
    /// Ustawienie konfiguracyjne dla recenzji o wydawnictwie
    /// </summary>
    public class PublishingReviewCfg : EntityTypeConfiguration<PublishingReview>
    {
        public PublishingReviewCfg()
        {
            Property(p => p.Date).IsRequired();
            Property(p => p.ReviewRate).IsRequired();
            Property(p => p.Description).IsRequired().HasMaxLength(500);
            HasRequired(p => p.Publishing).WithMany(publishing => publishing.PublishingReviews);
        }
    }
}