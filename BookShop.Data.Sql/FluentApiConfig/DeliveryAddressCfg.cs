using System.Data.Entity.ModelConfiguration;

namespace BookShop.Data.Sql.FluentApiConfig
{
    /// <summary>
    /// Ustawienie konfiguracyjne dla adresu pod który ma być wysła przesyłka
    /// </summary>
    public class DeliveryAddressCfg : EntityTypeConfiguration<DeliveryAddress>
    {
        public DeliveryAddressCfg()
        {
            Property(d => d.FirstName).IsRequired().HasMaxLength(50);
            Property(d => d.LastName).IsRequired().HasMaxLength(50);
            Property(d => d.Street).IsRequired().HasMaxLength(50);
            Property(d => d.City).IsRequired().HasMaxLength(50);
            Property(d => d.PostCode).IsRequired().HasMaxLength(6);
            Property(d => d.PhoneNumber).IsRequired().HasMaxLength(11);
        }
    }
}