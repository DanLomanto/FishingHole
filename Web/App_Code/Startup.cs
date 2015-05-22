using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FishingHole.Startup))]
namespace FishingHole
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
