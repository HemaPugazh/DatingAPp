using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
          //  CreateHostBuilder(args).Build().Run();
             var host = CreateHostBuilder(args).Build();
             using var scope = host.Services.CreateScope();
             var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<DataContext>();
                var userManager=services.GetRequiredService<UserManager<AppUser>>();
                var roleManager=services.GetRequiredService<RoleManager<AppRole>>();
                await context.Database.MigrateAsync();
                await Seed.SeedUsers(userManager,roleManager);
            }
            catch (Exception ex)
            {
                var loggger = services.GetRequiredService<ILogger<Program>>();
                loggger.LogError(ex,"An error occured during migration");
            }
           await host.RunAsync();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
