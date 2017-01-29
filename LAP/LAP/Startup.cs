using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LAP.Startup))]
namespace LAP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
         
        }
    }
}
