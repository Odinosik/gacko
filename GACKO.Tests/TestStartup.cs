using Autofac;
using FluentMigrator.Runner;
using GACKO.DB;
using GACKO.DB.DaoModels;
using GACKO.DB.Migrations;
using GACKO.DIModules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace GACKO.Tests
{
    public class TestStartup
    {
        public TestStartup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _environment = env;
            TestStartup.ENVIRONMENT_VARIABLE = env.EnvironmentName;
        }

        private IWebHostEnvironment _environment { get; }

        private static string ENVIRONMENT_VARIABLE { get; set; }

        public static string GetEnvironmentVariable() => TestStartup.ENVIRONMENT_VARIABLE;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Log.Information(GetEnvironmentVariable());

            services.AddDbContext<GackoDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDbForTesting"));
            services.AddDefaultIdentity<DaoUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<DaoRole>()
                .AddRoleManager<RoleManager<DaoRole>>()
                .AddSignInManager<SignInManager<DaoUser>>()
                .AddEntityFrameworkStores<GackoDbContext>();

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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

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
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<DbContextOptionsFactory>()
                    .AsImplementedInterfaces();

            builder.RegisterModule(new MapperModule());
            builder.RegisterModule(new RepositoriesModule());
            builder.RegisterModule(new ServicesModule());
        }
    }
}
