using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuizNSwap.Areas.Gameplay.SignalRHubs;
using QuizNSwap.Data;
using QuizNSwap.Data.Models;

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

            /* MSDN:
             * 
             * Entity Framework contexts

Entity Framework contexts are usually added to the service container using the scoped lifetime 
because web app database operations are normally scoped to the client request. 
The default lifetime is scoped if a lifetime isn't specified by an AddDbContext<TContext> overload 
when registering the database context. Services of a given lifetime shouldn't use a database context 
with a shorter lifetime than the service.
             */
            services
                .AddDbContext<QuizNSwapContext>(options =>
                    options
                        .UseSqlite(Configuration
                            .GetConnectionString("DefaultConnection")));

            services
                .AddIdentity<User, IdentityRole>(opts =>
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

            services.ConfigureApplicationCookie(options => options.LoginPath = "/");

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

                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app
                .UseEndpoints(endpoints =>
                {
                    endpoints
                        .MapControllerRoute(name: "defaultDashboardAreaView",
                        pattern: "{area:exists}/{controller=Home}/{action=Index}");

                    //this one will try to get you to index if you specify area and controller
                    endpoints
                        .MapControllerRoute(name: "defaultActionSpecifiedAreaNController",
                        pattern: "{area:exists}/{controller}/{action=Index}");

                    //this one is for the action methods of the start-no-area place
                    endpoints
                        .MapControllerRoute(name: "ThreeParamsSpecified",
                        pattern: "{area:exists}/{controller}/{action}");

                    //this one is for appending index to a controller you specify in the start-no-area place
                    endpoints
                        .MapControllerRoute(name: "startDefaultAction",
                        pattern: "{controller}/{action=Index}");

                    //the start page
                    endpoints
                        .MapControllerRoute(name: "start",
                        pattern: "{controller=User}/{action=Index}");
                    //TODO: I don't want action methods and Index appended to the address bar.

                    endpoints.MapHub<ChatHub>("/chatHub"); //name of hub class
                });
        }
    }
}
