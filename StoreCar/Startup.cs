using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreCar.Startup))]
namespace StoreCar
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
