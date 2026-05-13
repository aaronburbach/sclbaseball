using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SclBaseball.Startup))]
namespace SclBaseball
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
