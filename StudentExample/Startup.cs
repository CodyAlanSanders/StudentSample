using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentExample.Startup))]
namespace StudentExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
