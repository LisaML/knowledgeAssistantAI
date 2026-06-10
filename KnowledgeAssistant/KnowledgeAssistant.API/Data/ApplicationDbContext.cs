using Microsoft.EntityFrameworkCore;
using KnowledgeAssistant.API.Models;

namespace KnowledgeAssistant.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<BusinessRecord> BusinessRecords => Set<BusinessRecord>();

    public DbSet<AIAnalysis> AIAnalyses => Set<AIAnalysis>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AIAnalysis>()
            .HasOne(a => a.BusinessRecord)
            .WithMany()
            .HasForeignKey(a => a.BusinessRecordId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}