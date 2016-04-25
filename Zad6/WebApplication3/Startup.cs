using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(WebApplication3.Startup))]
namespace WebApplication3
{
    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
           
        }
    }
}