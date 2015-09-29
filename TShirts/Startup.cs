using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TShirts.Startup))]
namespace TShirts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
