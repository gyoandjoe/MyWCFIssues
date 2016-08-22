using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyWCFIssues.Web.Startup))]
namespace MyWCFIssues.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
