using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dabravata.Web.Startup))]
namespace Dabravata.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
