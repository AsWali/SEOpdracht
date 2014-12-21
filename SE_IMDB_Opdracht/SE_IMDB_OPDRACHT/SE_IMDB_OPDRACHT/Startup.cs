using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SE_IMDB_OPDRACHT.Startup))]
namespace SE_IMDB_OPDRACHT
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
