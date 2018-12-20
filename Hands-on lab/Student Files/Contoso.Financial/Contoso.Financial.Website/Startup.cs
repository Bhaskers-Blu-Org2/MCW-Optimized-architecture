using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Contoso.Financial.Website.Startup))]
namespace Contoso.Financial.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
