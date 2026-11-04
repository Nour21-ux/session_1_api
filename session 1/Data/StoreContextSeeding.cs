using session_1.Entities;
using System.Text.Json;

namespace session_1.Data
{
    public static class StoreContextSeeding
    {
        public async static Task SeedAsync(ApplicationDbContext dbContext)
        {
            if(!dbContext.Doctors.Any())
            {
                var doctorsdata = File.ReadAllText("F:\\DEPI\\WEB-API\\Session 01\\Assignment\\session 1\\session 1\\Data\\Seeding\\Doctors.json");
                var doctors= JsonSerializer.Deserialize<List<Doctor>>(doctorsdata);
                if (doctors is null)
                    return;
                await dbContext.Doctors.AddRangeAsync(doctors);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
