using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApp2.Startup))]
namespace WebApp2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
