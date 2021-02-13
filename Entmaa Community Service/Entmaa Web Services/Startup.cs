using Entmaa_Web_Services.App_Start;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Entmaa_Web_Services.Startup))]
namespace Entmaa_Web_Services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            HangfireConfig.ConfigureHangfire(app);
        }
    }
}
