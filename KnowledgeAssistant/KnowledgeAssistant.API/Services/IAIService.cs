namespace KnowledgeAssistant.API.Services;

public interface IAIService
{
    Task<string> GenerateSummaryAsync(string content);

    Task<string> ClassifyAsync(string content);

    Task<string> GenerateRecommendationsAsync(string content);

    Task<string> AskAsync(string question, string context);
}