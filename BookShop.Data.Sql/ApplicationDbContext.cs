using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BookShop.Data.Sql.FluentApiConfig;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Data.Sql
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddress { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<SubMainCategory> SubMainCategories { get; set; }

        public ApplicationDbContext(string connectionstring = "BookShopDbAzure")
            : base(connectionstring, throwIfV1Schema: false)
        {
        }

        /// <summary>
        /// Zainicjowanie ustawień konfiguracyjnych dla poszczególnych encji
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationUserCfg());
            modelBuilder.Configurations.Add(new AuthorCfg());
            modelBuilder.Configurations.Add(new AuthorReviewCfg());
            modelBuilder.Configurations.Add(new BookCfg());
            modelBuilder.Configurations.Add(new BookCategoryCfg());
            modelBuilder.Configurations.Add(new BookReviewCfg());
            modelBuilder.Configurations.Add(new DeliveryCfg());
            modelBuilder.Configurations.Add(new DeliveryAddressCfg());
            modelBuilder.Configurations.Add(new MainCategoryCfg());
            modelBuilder.Configurations.Add(new PaymentCfg());
            modelBuilder.Configurations.Add(new PublishingsCfg());
            modelBuilder.Configurations.Add(new PublishingReviewCfg());
            modelBuilder.Configurations.Add(new SubMainCategoryCfg());
            modelBuilder.Configurations.Add(new TransactionCfg());
            modelBuilder.Configurations.Add(new TransactionBookQuantityCfg());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}