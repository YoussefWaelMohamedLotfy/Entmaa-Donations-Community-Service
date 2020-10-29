using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Entmaa_Web_Services.Startup))]
namespace Entmaa_Web_Services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
