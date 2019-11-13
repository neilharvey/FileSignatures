using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileSignatures;
using FileSignatures.Formats;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // For this example we will only recognise image-based formats.
            var recognised = FileFormatLocator.GetFormats().OfType<Image>();
            var inspector = new FileFormatInspector(recognised);
            services.AddSingleton<IFileFormatInspector>(inspector);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(x =>
            {
                x.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
