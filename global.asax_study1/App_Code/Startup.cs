using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(global.asax_study.Startup))]
namespace global.asax_study
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
