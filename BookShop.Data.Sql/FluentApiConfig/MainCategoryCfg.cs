using System.Data.Entity.ModelConfiguration;

namespace BookShop.Data.Sql.FluentApiConfig
{
    /// <summary>
    /// Ustawienie konfiguracyjne dla główych kategorii
    /// </summary>
    public class MainCategoryCfg : EntityTypeConfiguration<MainCategory>
    {
        public MainCategoryCfg()
        {
            Property(m => m.Name).IsRequired().HasMaxLength(20);
            Property(m => m.NameForDisplay).IsRequired().HasMaxLength(20);
            HasMany(m => m.SubMainCategories).WithRequired(s => s.MainCategory);
        }
    }
}