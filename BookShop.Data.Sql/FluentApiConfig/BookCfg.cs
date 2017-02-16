using System.Data.Entity.ModelConfiguration;

namespace BookShop.Data.Sql.FluentApiConfig
{
    /// <summary>
    /// Ustawienie konfiguracyjne dla książki
    /// </summary>
    public class BookCfg : EntityTypeConfiguration<Book>
    {
        public BookCfg()
        {
            Property(b => b.Title).IsRequired().HasMaxLength(100);
            Property(b => b.TitleForDisplay).IsRequired().HasMaxLength(100);
            Property(b => b.PublishingId).IsRequired();
            Property(b => b.PublishDate).IsRequired();
            Property(b => b.ISBN).IsRequired().HasMaxLength(13);
            Property(b => b.PageSize).IsOptional();
            Property(b => b.BookSize).IsOptional().HasMaxLength(20);
            Property(b => b.Image).IsOptional();
            Property(b => b.Bestseller).IsOptional();
            Property(b => b.Language).IsRequired();
            Property(b => b.Cover).IsOptional();
            Property(b => b.Description).IsRequired();
            Property(b => b.Price).IsRequired();
            Property(b => b.Quantity).IsRequired();
            HasRequired(b => b.Publishing).WithMany(p => p.Books);            
            HasMany(b => b.BookCategories).WithMany(c => c.Books)
                    .Map(ab => ab.MapLeftKey("BookId").MapRightKey("BookCategoryId").ToTable("BookBookCategory"));
            HasMany(b => b.SubMainCategories).WithMany(s => s.Books)
                    .Map(ab => ab.MapLeftKey("BookId").MapRightKey("SubMainCategoryId").ToTable("BookSubMainCategory"));
        }
    }
}