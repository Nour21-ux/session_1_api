using Microsoft.EntityFrameworkCore;
using session_1.Data;
using session_1.Helper;
using session_1.Reposatories;
using session_1.Services;

namespace session_1.Extinsions
{
    public static class AppServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration) 
        {
            #region session 1
            //builder.Services.AddOpenApi();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefultSqlConnection"));
            });
            #endregion
            #region Session 2
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<PatientProfile>();
                cfg.AddProfile<DoctorProfile>();
            });
            services.AddScoped<IDoctorReposatory, DoctorReposatory>();
            services.AddScoped(typeof(IGenericReposatory<>), typeof(GenericReposatory<>));
            services.AddScoped<IDoctorService, DoctorService>();
            #endregion
            return services;
        }
    }
}
