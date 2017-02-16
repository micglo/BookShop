using System.Data.Entity.ModelConfiguration;

namespace BookShop.Data.Sql.FluentApiConfig
{
    /// <summary>
    /// Ustawienie konfiguracyjne dla podkategorii dla głównych kategorii
    /// </summary>
    public class SubMainCategoryCfg : EntityTypeConfiguration<SubMainCategory>
    {
        public SubMainCategoryCfg()
        {
            Property(s => s.Name).IsRequired().HasMaxLength(100);
            Property(s => s.NameForDisplay).IsRequired().HasMaxLength(100);
        }
    }
}