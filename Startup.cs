using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CDWebShop.Startup))]
namespace CDWebShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
