using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KopGelMarket.Startup))]
namespace KopGelMarket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
