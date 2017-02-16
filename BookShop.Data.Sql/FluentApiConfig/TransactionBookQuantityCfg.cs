using System.Data.Entity.ModelConfiguration;

namespace BookShop.Data.Sql.FluentApiConfig
{
    /// <summary>
    /// Ustawienie konfiguracyjne dla powiązania pomiedzy zakupionym produktem, a jego ilością
    /// </summary>
    public class TransactionBookQuantityCfg : EntityTypeConfiguration<TransactionBookQuantity>
    {
        public TransactionBookQuantityCfg()
        {
            Property(t => t.Quantity).IsRequired();
            Property(t => t.BookPrice).IsRequired();
            HasRequired(t => t.Book).WithMany(b => b.TransactionBookQuantitys);
            HasRequired(t => t.Transaction);
        }
    }
}