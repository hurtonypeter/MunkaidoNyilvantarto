using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MunkaidoNyilvantarto.Startup))]
namespace MunkaidoNyilvantarto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
