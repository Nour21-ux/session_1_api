using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using session_1.Entities;
using System.Reflection.Emit;

namespace session_1.Data.Configrations
{
    public class AppointmentConfigration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasQueryFilter(a => !a.Patient.IsDeleted);
            builder.HasKey(a => new { a.PatientId, a.DoctorId });

            builder.HasOne(a => a.Patient)
                        .WithMany(p => p.Appointments)
                        .HasForeignKey(a => a.PatientId);

            builder.HasOne(a => a.Doctor)
                        .WithMany(d => d.Appointments)
                        .HasForeignKey(a => a.DoctorId);
        }
    }
}
