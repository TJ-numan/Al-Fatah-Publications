using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BLL.Startup))]
namespace BLL
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
