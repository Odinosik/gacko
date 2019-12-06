using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper.Configuration;
using GACKO.DB;
using GACKO.DIModules;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace GACKO.Tests
{
    public class GackoWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove the app's ApplicationDbContext registration.
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<GackoDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add ApplicationDbContext using an in-memory database for testing.
                services.AddDbContext<GackoDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryDbForTesting"));

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                services.AddAutofac();

                // Create a scope to obtain a reference to the database
                // context (ApplicationDbContext).
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<GackoDbContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<GackoWebApplicationFactory<TStartup>>>();

                    // Ensure the database is created.
                    db.Database.EnsureCreated();

                    try
                    {
                        // Seed the database with test data.
                        //Utilities.InitializeDbForTests(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                            "database with test messages. Error: {Message}", ex.Message);
                    }
                }
            })
            .ConfigureTestContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterType<DbContextOptionsFactory>()
                    .AsImplementedInterfaces();

                builder.RegisterModule(new MapperModule());
                builder.RegisterModule(new RepositoriesModule());
                builder.RegisterModule(new ServicesModule());
            });
        }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder(null)
                          .UseStartup<TStartup>();
        }
    }
}
