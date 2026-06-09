namespace KnowledgeAssistant.API.Services;

public class MockAIService : IAIService
{
    public Task<string> GenerateSummaryAsync(string content)
    {
        return Task.FromResult($"Resumen generado del contenido: {content.Substring(0, Math.Min(content.Length, 80))}...");
    }

    public Task<string> ClassifyAsync(string content)
    {
        return Task.FromResult("Calidad");
    }

    public Task<string> GenerateRecommendationsAsync(string content)
    {
        return Task.FromResult("1. Revisar el proceso.\n2. Documentar hallazgos.\n3. Dar seguimiento.");
    }

    public Task<string> AskAsync(string question, string context)
    {
        return Task.FromResult($"Respuesta basada en la información registrada para la pregunta: {question}");
    }
}