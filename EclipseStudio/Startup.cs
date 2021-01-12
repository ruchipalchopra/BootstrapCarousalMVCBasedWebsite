using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EclipseStudio.Startup))]
namespace EclipseStudio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
