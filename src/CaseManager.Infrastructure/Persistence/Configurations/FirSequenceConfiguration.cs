using CaseManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseManager.Infrastructure.Persistence.Configurations;

public class FirSequenceConfiguration : IEntityTypeConfiguration<FirSequence>
{
    public void Configure(EntityTypeBuilder<FirSequence> builder)
    {
        builder.ToTable("fir_sequence");

        builder.HasKey(x => new { x.StationId, x.Year });

        builder.Property(x => x.CurrentValue).IsRequired();
    }
}