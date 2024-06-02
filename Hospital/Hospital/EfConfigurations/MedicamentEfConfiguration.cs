using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.EfConfigurations;

public class MedicamentEfConfiguration: IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder.HasKey(m => m.IdMedicament);
        builder.Property(m => m.IdMedicament).ValueGeneratedOnAdd();

        builder.Property(m => m.Name).IsRequired(true).HasMaxLength(100);
        builder.Property(m => m.Description).IsRequired(true).HasMaxLength(100);
        builder.Property(m => m.Type).IsRequired(true).HasMaxLength(100);
    }
}