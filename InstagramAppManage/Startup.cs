using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InstagramAppManage.Startup))]
namespace InstagramAppManage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
