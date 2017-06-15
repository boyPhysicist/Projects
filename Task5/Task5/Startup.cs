using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Task5.Startup))]
namespace Task5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
