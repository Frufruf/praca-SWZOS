using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SWZOS.Models.User;
using SWZOS.Repositories;
using SWZOS.Services;
using SWZOS_Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWZOS
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            services.AddHttpContextAccessor();

            services.AddMvc();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddDbContext<SWZOSContext>(a =>
                a.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), 
                b => b.MigrationsAssembly("SWZOS")));

            services.AddTransient<IEmailSender, EmailSender>();

            #region DependencyInjection

            services.AddScoped<UsersRepository, UsersRepository>();
            services.AddScoped<AccountRepository, AccountRepository>();
            services.AddScoped<ReservationsRepository, ReservationsRepository>();
            services.AddScoped<PriceListRepository, PriceListRepository>();
            services.AddScoped<BlackListRepository, BlackListRepository>();
            services.AddScoped<PitchesRepository, PitchesRepository>();
            services.AddScoped<EquipmentRepository, EquipmentRepository>();

            #endregion
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            //TODO poczytaæ o polityce Cookies
            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict
            };

            app.UseCookiePolicy(cookiePolicyOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
