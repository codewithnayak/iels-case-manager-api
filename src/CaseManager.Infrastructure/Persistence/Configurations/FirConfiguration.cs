using CaseManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseManager.Infrastructure.Persistence.Configurations;

public class FirConfiguration : IEntityTypeConfiguration<Fir>
{
    public void Configure(EntityTypeBuilder<Fir> builder)
    {
        builder.HasKey(f => f.FirId);

        builder.Property(f => f.FirNumber).IsRequired().HasMaxLength(50);
        builder.Property(f => f.ComplainantName).IsRequired().HasMaxLength(100);
        builder.Property(f => f.ComplainantPhone).IsRequired().HasMaxLength(15);
        builder.Property(f => f.CrimeType).IsRequired();
        builder.Property(f => f.StationId).IsRequired();
        builder.Property(f => f.StateCode).IsRequired();

        builder.Property(f => f.CreatedAt).HasDefaultValueSql("NOW()");
    }
}