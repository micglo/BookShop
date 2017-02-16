using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Data.Sql.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            SeedRoles(context);
            SeedUsers(context);
            SeedDelivery(context);
            SeedPayment(context);

            base.Seed(context);
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Employer"))
            {
                var role = new IdentityRole { Name = "Employer" };
                manager.Create(role);
            }
        }

        private static void SeedUsers(ApplicationDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            if (!context.Users.Any(u => u.UserName == "michalglowaczewski@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "michalglowaczewski@gmail.com",
                    Email = "michalglowaczewski@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Micha³",
                    LastName = "G³owaczewski",
                    PhoneNumber = "123123123",
                    Street = "Ulica 123",
                    City = "Opole",
                    PostCode = "12-123"
                };

                manager.Create(user, "P@$$w0rd1");
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "michalglowaczewski1@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "michalglowaczewski1@gmail.com",
                    Email = "michalglowaczewski1@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Micha³",
                    LastName = "G³owaczewski",
                    PhoneNumber = "123123123",
                    Street = "Ulica 123",
                    City = "Opole",
                    PostCode = "12-123"
                };

                manager.Create(user, "P@$$w0rd1");
                manager.AddToRole(user.Id, "Employer");
            }
        }

        private void SeedDelivery(ApplicationDbContext context)
        {
            context.Delivery.AddOrUpdate(
              d => d.DeliveryType,
              new Delivery { DeliveryType = "Przesy³ka kurierska" , Price = 12.7M },
              new Delivery { DeliveryType = "Przesy³ka pocztowa", Price = 10.7M },
              new Delivery { DeliveryType = "Odbiór osobisty", Price = 0 },
              new Delivery { DeliveryType = "Przesy³ka elektroniczna", Price = 0 }
            );
        }

        private void SeedPayment(ApplicationDbContext context)
        {
            context.Payment.AddOrUpdate(
              d => d.PaymentType,
              new Payment { PaymentType = "P³atnoœæ kart¹ kredytow¹" },
              new Payment { PaymentType = "P³atnoœæ przelewem bankowym" },
              new Payment { PaymentType = "P³atnoœæ za pobraniem" },
              new Payment { PaymentType = "P³atnoœæ przy odbiorze" }
            );
        }
    }
}
