using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookShop.Web.Startup))]
namespace BookShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = SimpleInjectorInitializer.Initialize(app);
            ConfigureAuth(app, container);
        }
    }
}
