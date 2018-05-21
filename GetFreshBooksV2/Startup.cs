using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GetFreshBooksV2.Startup))]
namespace GetFreshBooksV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
