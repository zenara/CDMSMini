using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CDMS.Startup))]
namespace CDMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
