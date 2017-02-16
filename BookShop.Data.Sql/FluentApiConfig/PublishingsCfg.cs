using System.Data.Entity.ModelConfiguration;

namespace BookShop.Data.Sql.FluentApiConfig
{
    /// <summary>
    /// Ustawienie konfiguracyjne dla wydawnictwa
    /// </summary>
    public class PublishingsCfg : EntityTypeConfiguration<Publishing>
    {
        public PublishingsCfg()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(100);
            Property(p => p.NameForDisplay).IsRequired().HasMaxLength(100);
            Property(p => p.Image).IsOptional();
            Property(p => p.Description).IsOptional();
        }
    }
}