using System.Data.Entity.ModelConfiguration;

namespace BookShop.Data.Sql.FluentApiConfig
{
    /// <summary>
    /// Ustawienie konfiguracyjne dla zapłaty
    /// </summary>
    public class PaymentCfg : EntityTypeConfiguration<Payment>
    {
        public PaymentCfg()
        {
            Property(a => a.PaymentType).IsRequired();
        }
    }
}