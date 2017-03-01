using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sabr.Startup))]
namespace Sabr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
