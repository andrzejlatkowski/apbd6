using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.EfConfigurations;

public class PrescriptionEfConfiguration: IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(pr => pr.IdPrescription);
        builder.Property(pr => pr.IdPrescription).ValueGeneratedOnAdd();

        builder.Property(pr => pr.Date).IsRequired(true);
        builder.Property(pr => pr.DueDate).IsRequired(true);
        builder.Property(pr => pr.DueDate).IsRequired(true);

        builder.HasOne(pr => pr.IdPatientNavigation)
            .WithMany(p => p.Prescriptions)
            .HasForeignKey(pr => pr.IdPrescription)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(pr => pr.IdDoctorNavigation)
            .WithMany(d => d.Prescriptions)
            .HasForeignKey(pr => pr.IdDoctor)
            .OnDelete(DeleteBehavior.Cascade);
    }
}