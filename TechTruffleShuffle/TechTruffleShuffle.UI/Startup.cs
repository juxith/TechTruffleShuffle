using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechTruffleShuffle.UI.Startup))]
namespace TechTruffleShuffle.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
