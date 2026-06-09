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
}