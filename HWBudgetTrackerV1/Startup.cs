using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HWBudgetTrackerV1.Startup))]
namespace HWBudgetTrackerV1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
