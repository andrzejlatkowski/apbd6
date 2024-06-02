using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.EfConfigurations;

public class PatientEfConfiguration: IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.IdPatient);
        builder.Property(p => p.IdPatient).ValueGeneratedOnAdd();

        builder.Property(p=>p.FirstName).IsRequired(true).HasMaxLength(100);
        builder.Property(p=>p.LastName).IsRequired(true).HasMaxLength(100);
        builder.Property(p => p.BirthDate).IsRequired(true);
    }
}