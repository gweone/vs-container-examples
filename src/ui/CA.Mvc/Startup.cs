using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CA.Mvc.Startup))]
namespace CA.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
