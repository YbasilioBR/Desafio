using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Util;

namespace DesafioNeoAssist
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseMvc();
                
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "ById",
                template: "{Ticket}/{Get}/{id:int}",
                defaults: new { controller = "Ticket", action = "Get" });

                routes.MapRoute(
                name: "OrderByCreate",
                template: "{Ticket}/{GetByCreate}",
                defaults: new { controller = "Ticket", action = "GetByCreate" });

                routes.MapRoute(
                name: "OrderByUpdate",
                template: "{Ticket}/{GetByUpdate}",
                defaults: new { controller = "Ticket", action = "GetByUpdate" });

                routes.MapRoute(
                name: "OrderByPriority",
                template: "{Ticket}/{GetByPriority}",
                defaults: new { controller = "Ticket", action = "GetByPriority" });


                routes.MapRoute(
                name: "ByDate",
                template: "{Ticket}/{GetInDate}/{Inicial}/{Final}",
                defaults: new { controller = "Ticket", action = "GetInDate", Inicial = "", Final = "" });

                routes.MapRoute("default", "{controller=Home}/{action=Index}");

            });
        }
    }
}
