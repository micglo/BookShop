using System.Data.Entity.ModelConfiguration;

namespace BookShop.Data.Sql.FluentApiConfig
{
    /// <summary>
    /// Ustawienie konfiguracyjne dla kategorii
    /// </summary>
    public class BookCategoryCfg : EntityTypeConfiguration<BookCategory>
    {
        public BookCategoryCfg()
        {
            Property(b => b.Name).IsRequired().HasMaxLength(100);
            Property(b => b.NameForDisplay).IsRequired().HasMaxLength(100);
            HasRequired(b => b.SubMainCategory).WithMany(s => s.BookCategories);
        }
    }
}