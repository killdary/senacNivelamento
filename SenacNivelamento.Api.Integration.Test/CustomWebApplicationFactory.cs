using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using SenacNivelamento.Infra.Writing.Data;

namespace SenacNivelamento.Api.Integration.Test
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(
                            d => d.ServiceType ==
                                typeof(DbContextOptions<WritingContext>));


                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }
                    services.AddDbContext<WritingContext>(options =>
                                    {
                                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                                    });


                    var sp = services.BuildServiceProvider();

                    using (var scope = sp.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var context = scopedServices.GetRequiredService<WritingContext>();
                        var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                        context.Database.EnsureCreated();

                        try
                        {
                            SeedSampleData(context);
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "An error occurred seeding the database with test messages. Error: {Message}", ex.Message);
                        }
                    }
                })
                    .UseEnvironment("Test");
        }

        public static void SeedSampleData(WritingContext context)
        {
        }
    }
}
