
using Microsoft.EntityFrameworkCore;
using session_1.Data;
using session_1.Extinsions;

namespace session_1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddServices(builder.Configuration);

            var app = builder.Build();

            #region Seeding
            //Automatic migration
            using var scope = app.Services.CreateScope();
            var services= scope.ServiceProvider;
            var LoogerFactory=services.GetRequiredService<ILoggerFactory>();
            try
            {
                using var dbContext = services.GetRequiredService<ApplicationDbContext>();
                await dbContext.Database.MigrateAsync();
                await StoreContextSeeding.SeedAsync(dbContext);

            }
            catch (Exception ex)
            {
                var looger = LoogerFactory.CreateLogger<Program>();
                looger.LogError(ex, ex.Message);
            }

            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
