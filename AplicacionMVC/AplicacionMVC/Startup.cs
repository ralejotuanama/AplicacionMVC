using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AplicacionMVC.Startup))]
namespace AplicacionMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
