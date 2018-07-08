using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedStore_Mvc.Startup))]
namespace RedStore_Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
