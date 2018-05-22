using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GetFreshBooks.Startup))]
namespace GetFreshBooks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
