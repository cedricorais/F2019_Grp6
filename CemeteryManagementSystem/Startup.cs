using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CemeteryManagementSystem.Startup))]
namespace CemeteryManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
