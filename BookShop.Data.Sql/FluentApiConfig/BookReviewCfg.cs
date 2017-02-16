using System.Data.Entity.ModelConfiguration;

namespace BookShop.Data.Sql.FluentApiConfig
{
    /// <summary>
    /// Ustawienie konfiguracyjne dla recenzji o książce
    /// </summary>
    public class BookReviewCfg : EntityTypeConfiguration<BookReview>
    {
        public BookReviewCfg()
        {
            Property(b => b.Date).IsRequired();
            Property(b => b.ReviewRate).IsRequired();
            Property(b => b.Description).IsRequired().HasMaxLength(500);
            HasRequired(b => b.Book).WithMany(book => book.BookReviews);
        }
    }
}