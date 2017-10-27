using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechTruffleShuffle.Data.Startup))]
namespace TechTruffleShuffle.Data
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
