using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetTest.UI.Startup))]
namespace NetTest.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
