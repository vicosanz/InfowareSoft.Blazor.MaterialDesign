using InfowareSoft.Blazor.MaterialDesign;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJSNotificationService();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
