using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.EfConfigurations;

public class DoctorEfConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(d => d.IdDoctor);
        builder.Property(d => d.IdDoctor).ValueGeneratedOnAdd();

        builder.Property(d => d.FirstName).IsRequired(true).HasMaxLength(100);
        builder.Property(d => d.LastName).IsRequired(true).HasMaxLength(100);
        builder.Property(d => d.Email).IsRequired(true).HasMaxLength(100);
    }
}