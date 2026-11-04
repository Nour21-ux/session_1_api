using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using session_1.Entities;

namespace session_1.Data.Configrations
{
    public class PatientConfigration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
