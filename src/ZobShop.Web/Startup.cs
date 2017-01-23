using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZobShop.Web.Startup))]
namespace ZobShop.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
