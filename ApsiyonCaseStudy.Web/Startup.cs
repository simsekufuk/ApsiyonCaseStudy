using ApsiyonCaseStudy.Business.IOC;
using ApsiyonCaseStudy.Data.IOC;
using ApsiyonCaseStudy.Entity.DataContext;
using ApsiyonCaseStudy.Utilies.IOC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApsiyonCaseStudy.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApsiyonDBContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:ApsiyonDBConnectionString"]));

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            BusinessDependencyResolver.RegisterServices(services);
            DataDependencyResolver.RegisterServices(services);
            UtiliesDependencyResolver.RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Logger}/{action=Add}/{id?}");
            });
        }
    }
}
