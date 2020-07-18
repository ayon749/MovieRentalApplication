using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineMovieRental.Startup))]
namespace OnlineMovieRental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
