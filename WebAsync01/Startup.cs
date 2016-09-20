using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAsync01.Startup))]
namespace WebAsync01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
