using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClothShopK.Web.Startup))]
namespace ClothShopK.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
