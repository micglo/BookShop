using System.Data.Entity.ModelConfiguration;

namespace BookShop.Data.Sql.FluentApiConfig
{
    /// <summary>
    /// Ustawienie konfiguracyjne dla transakcji
    /// </summary>
    public class TransactionCfg : EntityTypeConfiguration<Transaction>
    {
        public TransactionCfg()
        {
            Property(t => t.TransactionDate).IsRequired();
            Property(t => t.TransactionStatus).IsRequired();
            Property(t => t.TransactionAmount).IsRequired();
            HasRequired(t => t.User).WithMany(p => p.Transactions); ;
            HasRequired(t => t.Payment).WithMany(p=>p.Transactions);
            HasRequired(t => t.Delivery).WithMany(p => p.Transactions); ;
            HasMany(t => t.TransactionBookQuantities).WithRequired(t => t.Transaction);
            HasRequired(t => t.DeliveryAddress).WithRequiredPrincipal(td => td.Transaction);
        }
    }
}