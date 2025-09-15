
namespace Ignite
{
    public class Program
    {
        private static readonly AutoResetEvent _closing = new AutoResetEvent(false);

        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Load configurations
            await RunAsync(args);


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }





            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            Console.WriteLine("Hello world!2");

            app.Run();
        }

        private static async Task RunAsync(string[] args)
        {

            var configService = new Services.Configs.ConfigService();
            await configService.LoadConfigs();

        }
    }
}
