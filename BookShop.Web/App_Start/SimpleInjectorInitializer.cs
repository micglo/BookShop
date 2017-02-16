using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using BookShop.Data;
using BookShop.Data.Sql;
using BookShop.Repository;
using BookShop.Repository.Interfaces;
using BookShop.Service;
using BookShop.Service.Interfaces;
using BookShop.Service.PatternMatching.BookSearch;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace BookShop.Web
{
    public static class SimpleInjectorInitializer
    {
        public static Container Initialize(IAppBuilder app)
        {
            var container = GetInitializeContainer(app);

            container.Verify();

            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));

            return container;
        }

        public static Container GetInitializeContainer(
                  IAppBuilder app)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.RegisterSingleton(app);

            container.Register(() => new ApplicationDbContext(), Lifestyle.Scoped);

            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(container.GetInstance<ApplicationDbContext>()), Lifestyle.Scoped);
            container.RegisterInitializer<ApplicationUserManager>(manager => InitializeUserManager(manager, app));

            container.Register<SignInManager<ApplicationUser, string>, ApplicationSignInManager>(Lifestyle.Scoped);
            container.Register(() => container.IsVerifying()
                ? new OwinContext(new Dictionary<string, object>()).Authentication
                : HttpContext.Current.GetOwinContext().Authentication, Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            container.Register<IAuthorService, AuthorService>(Lifestyle.Scoped);
            container.Register<IAuthorReviewService, AuthorReviewService>(Lifestyle.Scoped);
            container.Register<IBookService, BookService>(Lifestyle.Scoped);
            container.Register<IBookReviewService, BookReviewService>(Lifestyle.Scoped);
            container.Register<IMenuService, MenuService>(Lifestyle.Scoped);
            container.Register<IPublishingService, PublishingService>(Lifestyle.Scoped);
            container.Register<IPublishingReviewService, PublishingReviewService>(Lifestyle.Scoped);
            container.Register<IShoppingCartService, ShoppingCartService>(Lifestyle.Scoped);
            container.Register<ITransactionService, TransactionService>(Lifestyle.Scoped);

            container.Register<IPatternMatchingBookSearch, PatternMatchingBookSearch>(Lifestyle.Scoped);


            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();

            return container;
        }

        private static void InitializeUserManager(
            ApplicationUserManager manager, IAppBuilder app)
        {
            manager.UserValidator =
             new UserValidator<ApplicationUser>(manager)
             {
                 AllowOnlyAlphanumericUserNames = false,
                 RequireUniqueEmail = true
             };

            //Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            manager.EmailService = new EmailService();
            var dataProtectionProvider =
                 app.GetDataProtectionProvider();

            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"))
                    {
                        TokenLifespan = TimeSpan.FromHours(24)
                    };
            }
        }
    }
}