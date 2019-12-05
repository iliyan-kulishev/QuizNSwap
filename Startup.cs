using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using QuizNSwap.Data;
using QuizNSwap.Data.UnitOfWork;
using QuizNSwap.Data.Models;
using QuizNSwap.Areas.Gameplay.SignalRHubs;

namespace QuizNSwap
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
            services.AddControllersWithViews();

            services.AddSignalR();

            services.AddDbContext<QuizNSwapContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<QuizNSwapContext>()
            .AddDefaultTokenProviders();

            /*
             * although  /Account/Login is the default Url that clients are redirected to when authorization is
                required, you can specify your own Url in the  ConfigureServices method of the  Startup class by
                changing a configuration option when setting up the aSp.net Core identity services, like this:
                ...
                services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Users/Login");
             */
            //services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Users/SignIn");

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. 
                // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            /*Adds ASP.NET Core Identity to the request-handing pipeline,
            which allows user credentials to be associated with requests based on cookies or URL rewriting, meaning
            that details of user accounts are not directly included in the HTTP requests sent to the application or the
            responses it generates.*/
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    //pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    pattern: "{area:exists}/{controller=Home}/{action=Index}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area:exists}/{controller}/{action}/{id?}"
                );

                /*    
                     endpoints.MapControllerRoute(
                name: "areaRoute",
                pattern: "{area:exists}/{controller}/{action}",
                defaults: new { action = "Index" });

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "Index" });

            endpoints.MapControllerRoute(
                name: "api",
                pattern: "{controller}/{id?}");

        */


                endpoints.MapHub<ChatHub>("/chatHub");//name of hub class


            });

        }
    }
}
