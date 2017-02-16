using System.Data.Entity.ModelConfiguration;

namespace BookShop.Data.Sql.FluentApiConfig
{
    /// <summary>
    /// Ustawienie konfiguracyjne dla typu wysyłki
    /// </summary>
    public class DeliveryCfg : EntityTypeConfiguration<Delivery>
    {
        public DeliveryCfg()
        {
            Property(a => a.DeliveryType).IsRequired();
            Property(a => a.Price).IsRequired();
        }
    }
}