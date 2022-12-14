using CoreDemo.DataAccess.Concrete;
using CoreDemo.Entity.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo
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
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequireUppercase = false;
                x.Password.RequireLowercase = false;
                x.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<Context>();
            services.AddControllersWithViews();
            /*-------------------------------------------------------------------*/
            //##  Session Ekle / A?a??da App.UseSession() olarak ayr?ca ekleniyor. ##
            //services.AddSession();
            /*-------------------------------------------------------------------*/

            /*-------------------------------------------------------------------*/
            //##  Proje Seviyesinde Authentication ##
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            /*-------------------------------------------------------------------*/
            services.AddMvc();

            /*-------------------------------------------------------------------*/
            //##  Return Login Url ##
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/Login/Index";
            });
            /*-------------------------------------------------------------------*/
            services.ConfigureApplicationCookie(options =>
            {
                //## Cookie Ayarlar?
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.LoginPath = "/Login/Index/";
                options.AccessDeniedPath = new PathString("/Login/AccessDenied");
                options.SlidingExpiration = true;
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

            /*-------------------------------------------------------------------*/
            //## 404 Sayfas? ##
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");
            //Hata oldu?unda bu adrese status code ile birlikte gidecek.?stersek bu kod ile her durum i?in farkl? bir senaryo olu?turabiliriz.
            /*-------------------------------------------------------------------*/

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            /*-------------------------------------------------------------------*/
            //##Authentication eklendi.
            app.UseAuthentication();
            /*-------------------------------------------------------------------*/

            //app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
