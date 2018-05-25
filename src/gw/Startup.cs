namespace AureliaDotnetTemplateApi
{
    using System.Threading.Tasks;
    using AspNetCore.Proxy;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseProxy("weather/{path}", async args => await Task.FromResult("http://weather/" + args["path"]));
            app.UseProxy("dist/{path}", async args => await Task.FromResult("http://spa/dist/" + args["path"]));
            app.UseProxy(string.Empty, async _ => await Task.FromResult("http://spa/"));
        }
    }
}
