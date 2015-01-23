using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StringGaugeCalculatorSite.Startup))]
namespace StringGaugeCalculatorSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
