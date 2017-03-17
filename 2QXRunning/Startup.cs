using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2QXRunning.Startup))]
namespace _2QXRunning
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
