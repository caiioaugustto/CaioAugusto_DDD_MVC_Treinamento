using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaioAugusto.DDDMVCTreinamento.UI.Site.Startup))]
namespace CaioAugusto.DDDMVCTreinamento.UI.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
