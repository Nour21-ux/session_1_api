using Microsoft.EntityFrameworkCore;
using session_1.Data;

namespace session_1.Extinsions
{
    public static class AppServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration) 
        {
            //builder.Services.AddOpenApi();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefultSqlConnection"));
            });
            return services;
        }
    }
}
