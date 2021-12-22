using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ebook_Application.Startup))]
namespace Ebook_Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
