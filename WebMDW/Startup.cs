using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMDW.Startup))]
namespace WebMDW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
