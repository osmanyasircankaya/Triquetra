using Triquetra.Migrations;

namespace Triquetra.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args).Build();

            //using var scope = builder.Services.CreateScope();
            //var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            //ApplicationDbContextSeed.SeedSampleDataAsync(db);

            builder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}