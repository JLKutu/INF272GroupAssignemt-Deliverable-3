using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GroupProjectDonation272.Startup))]
namespace GroupProjectDonation272
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
