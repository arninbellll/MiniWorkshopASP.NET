using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiniWS.Startup))]
namespace MiniWS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
