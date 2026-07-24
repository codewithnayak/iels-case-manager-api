using Microsoft.EntityFrameworkCore;
using CaseManager.Domain.Entities;

namespace CaseManager.Infrastructure.Persistence;

public class CaseDbContext : DbContext
{
    public CaseDbContext(DbContextOptions<CaseDbContext> options) : base(options) {}

    public DbSet<Fir> Firs { get; set; }
    public DbSet<FirSequence> FirSequences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CaseDbContext).Assembly);
    }
}