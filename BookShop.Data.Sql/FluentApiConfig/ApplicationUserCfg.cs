using System.Data.Entity.ModelConfiguration;

namespace BookShop.Data.Sql.FluentApiConfig
{
    /// <summary>
    /// Ustawienie konfiguracyjne dla użytkownika
    /// </summary>
    public class ApplicationUserCfg : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserCfg()
        {
            Property(a => a.FirstName).IsOptional().HasMaxLength(50);
            Property(a => a.LastName).IsOptional().HasMaxLength(50);
            Property(a => a.PhoneNumber).IsOptional().HasMaxLength(11);
            Property(a => a.Street).IsOptional().HasMaxLength(50);
            Property(a => a.City).IsOptional().HasMaxLength(50);
            Property(a => a.PostCode).IsOptional().HasMaxLength(6);
            Property(a => a.IsCompany).IsRequired();
            Property(a => a.CompanyName).IsOptional().HasMaxLength(50);
            Property(a => a.Regon).IsOptional().HasMaxLength(9);
            Property(a => a.Nip).IsOptional().HasMaxLength(10);
            HasMany(a => a.BookReviews).WithRequired(r => r.User);
            HasMany(a => a.AuthorReviews).WithRequired(r => r.User);
            HasMany(a => a.PublishingReviews).WithRequired(r => r.User);
        }
    }
}