using System.Data.Entity.ModelConfiguration;

namespace BookShop.Data.Sql.FluentApiConfig
{
    /// <summary>
    /// Ustawienie konfiguracyjne dla recenzji o autorze
    /// </summary>
    public class AuthorReviewCfg : EntityTypeConfiguration<AuthorReview>
    {
        public AuthorReviewCfg()
        {
            Property(a => a.Date).IsRequired();
            Property(a => a.ReviewRate).IsRequired();
            Property(a => a.Description).IsRequired().HasMaxLength(500);
            HasRequired(a => a.Author).WithMany(author => author.AuthorReviews);
        }
    }
}