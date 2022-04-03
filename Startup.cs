using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sekretari_Demo.Startup))]
namespace Sekretari_Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
