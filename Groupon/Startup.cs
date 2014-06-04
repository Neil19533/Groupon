using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Groupon.Startup))]
namespace Groupon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
