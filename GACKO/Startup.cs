using Autofac;
using GACKO;
using GACKO.DB;
using GACKO.DB.DaoModels;
using GACKO.DIModules;
using GACKO.Shared.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace GACKO_MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _environment = env;
        }

        public IConfiguration Configuration { get; }

        private IWebHostEnvironment _environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GackoDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentityCore<DaoUser>(options => options.SignIn.RequireConfirmedAccount = false);
            new IdentityBuilder(typeof(DaoUser), typeof(DaoRole), services)
                .AddRoles<DaoRole>()
                .AddRoleManager<RoleManager<DaoRole>>()
                .AddSignInManager<SignInManager<DaoUser>>()
                .AddEntityFrameworkStores<GackoDbContext>()
                .AddDefaultTokenProviders();

            services.AddControllersWithViews();

            services.AddMvcCore(options =>
            {
                options.EnableEndpointRouting = false;
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/User/Login";
                options.AccessDeniedPath = "/User/Login";
                options.SlidingExpiration = true;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.Cookie.Name = "GACKO.AuthCookieAspNetCore";
                   options.LoginPath = "/User/Login";
                   options.Cookie.HttpOnly = true;
                   options.Cookie.SecurePolicy = _environment.IsDevelopment()
                     ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
                   options.Cookie.SameSite = SameSiteMode.Lax;
               })
               .AddIdentityCookies();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
                options.HttpOnly = HttpOnlyPolicy.None;
                options.Secure = _environment.IsDevelopment()
                  ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
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
                app.UseExceptionHandler("/Web/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRouting();

            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}"
                );
            });

            DatabaseInitialize(app);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new MapperModule());
            builder.RegisterModule(new RepositoriesModule());
            builder.RegisterModule(new ServicesModule());
        }

        private static void DatabaseInitialize(IApplicationBuilder app)
        {
            using (IServiceScope scope = app.ApplicationServices.CreateScope())
            {
                RoleManager<DaoRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<DaoRole>>();
                UserManager<DaoUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<DaoUser>>();
                var dbInitializer = new DbInitializer();
                dbInitializer.Initialize(userManager, roleManager).Wait();
            }
        }
    }
}
