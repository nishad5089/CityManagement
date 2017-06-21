using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CountryCityMangement.Startup))]
namespace CountryCityMangement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
