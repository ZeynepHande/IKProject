using IKProject_2512.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512
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
            services.AddSession(options =>
           options.IdleTimeout = TimeSpan.FromMinutes(60));

            services.AddControllersWithViews();
            services.AddDbContext<IKDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DataConnectionString"));
                //options.UseSqlServer(Configuration.GetConnectionString("DataConnectionString"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Platform Area yönlendirmesi
                endpoints.MapAreaControllerRoute(
                 name: "Platform",
                 areaName: "Platform",
                 pattern: "Platform/{controller=Home}/{action=Index}/{id?}"); //Platform area sayfa yönlendirmesi

                //Company Manager Area yönlendirmesi
                endpoints.MapAreaControllerRoute(
                 name: "CoMgr",
                 areaName: "CoMgr",
                 pattern: "CoMgr/{controller=Home}/{action=Index}/{id?}"); //Platform area sayfa yönlendirmesi

                //endpoints.MapControllerRoute(
                //      name: "areaDefault",
                //     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapControllerRoute(
                //     name: "Platform",
                //    pattern: "{controller=PlatformManager}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                      name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");


            });

        }
    }
}
