using System.Data.Entity.ModelConfiguration;

namespace BookShop.Data.Sql.FluentApiConfig
{
    /// <summary>
    /// Ustawienie konfiguracyjne dla autora
    /// </summary>
    public class AuthorCfg : EntityTypeConfiguration<Author>
    {
        public AuthorCfg()
        {
            Property(a => a.FirstName).IsRequired().HasMaxLength(50);
            Property(a => a.LastName).IsRequired().HasMaxLength(50);
            Property(a => a.LastNameForDisplay).IsRequired().HasMaxLength(50);
            Property(a => a.Description).IsOptional();
            HasMany(a => a.Books).WithMany(b => b.Author)
                    .Map(ab => ab.MapLeftKey("AuthorId").MapRightKey("BookId").ToTable("AuthorBook"));
        }
    }
}