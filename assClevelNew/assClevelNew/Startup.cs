using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(assClevelNew.Startup))]
namespace assClevelNew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
