using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarStore.Startup))]
namespace CarStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
