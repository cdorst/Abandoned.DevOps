using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace DevOps.Abstractions.Platforms.AspNetCore.StartupConfiguration
{
    public class PipelineConfigurationService
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ConfigureExceptionHandling(app, env);
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureExceptionHandling(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
        }
    }
}
