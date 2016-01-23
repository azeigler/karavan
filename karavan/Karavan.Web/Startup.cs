using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Karavan.Web.Startup))]
namespace Karavan.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
