using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5_AngularJS.Startup))]
namespace MVC5_AngularJS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
