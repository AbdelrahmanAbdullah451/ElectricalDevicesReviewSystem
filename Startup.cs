using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReviewArena.Startup))]
namespace ReviewArena
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
