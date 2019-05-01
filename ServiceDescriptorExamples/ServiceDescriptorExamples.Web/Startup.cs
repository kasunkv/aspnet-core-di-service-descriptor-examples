using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceDescriptorExamples.Web.Contracts;
using ServiceDescriptorExamples.Web.Services;

namespace ServiceDescriptorExamples.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Creating a new Instance of the ServiceDescriptor
            var oneService = new ServiceDescriptor(typeof(IOneService), typeof(OneService), ServiceLifetime.Scoped);
            services.Add(oneService);

            // Using the Describe() static method on the ServiceDescriptor
            var twoService = ServiceDescriptor.Describe(typeof(ITwoService), typeof(TwoService), ServiceLifetime.Scoped);
            services.Add(twoService);

            // Using the static method for the specific lifetime
            var threeService = ServiceDescriptor.Scoped(typeof(IThreeService), typeof(ThreeService));
            services.Add(threeService);

            // Using the static method for the specific lifetime
            var fourService = ServiceDescriptor.Scoped<IFourService, FourService>();
            services.Add(fourService);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
