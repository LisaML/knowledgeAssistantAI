using Microsoft.EntityFrameworkCore;
using KnowledgeAssistant.API.Data;
using KnowledgeAssistant.API.Models;

namespace KnowledgeAssistant.API.Services.Background;

public class AIAnalysisBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<AIAnalysisBackgroundService> _logger;

    public AIAnalysisBackgroundService(
        IServiceProvider serviceProvider,
        ILogger<AIAnalysisBackgroundService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope =
                    _serviceProvider.CreateScope();

                var context =
                    scope.ServiceProvider
                        .GetRequiredService<ApplicationDbContext>();

                var aiService =
                    scope.ServiceProvider
                        .GetRequiredService<IAIService>();

                var recordsWithoutAnalysis =
                    await context.BusinessRecords
                        .Where(record =>
                            !context.AIAnalyses.Any(analysis =>
                                analysis.BusinessRecordId == record.Id))
                        .Take(3)
                        .ToListAsync(stoppingToken);

                foreach (var record in recordsWithoutAnalysis)
                {
                    _logger.LogInformation(
                        "Automatic AI analysis started for record {RecordId}",
                        record.Id);

                    var analysis = new AIAnalysis
                    {
                        BusinessRecordId = record.Id,
                        Summary = await aiService.GenerateSummaryAsync(record.Content),
                        Classification = await aiService.ClassifyAsync(record.Content),
                        Recommendations = await aiService.GenerateRecommendationsAsync(record.Content),
                        CreatedAt = DateTime.UtcNow
                    };

                    context.AIAnalyses.Add(analysis);

                    await context.SaveChangesAsync(stoppingToken);

                    _logger.LogInformation(
                        "Automatic AI analysis completed for record {RecordId}",
                        record.Id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error running automatic AI analysis background service");
            }

            await Task.Delay(
                TimeSpan.FromMinutes(1),
                stoppingToken);
        }
    }
}