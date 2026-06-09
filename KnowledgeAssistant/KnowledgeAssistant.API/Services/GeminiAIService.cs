using Mscc.GenerativeAI;

namespace KnowledgeAssistant.API.Services;

public class GeminiAIService : IAIService
{
    private readonly string _apiKey;

    public GeminiAIService(IConfiguration configuration)
    {
        _apiKey = configuration["Gemini:ApiKey"]!;
    }

    public async Task<string> GenerateSummaryAsync(string content)
    {
        return await AskGemini(
            $"Resume el siguiente texto en máximo 5 líneas:\n{content}");
    }

    public async Task<string> ClassifyAsync(string content)
    {
        return await AskGemini(
            $"""
            Clasifica el siguiente contenido en una sola categoría:

            RH
            Ventas
            Producción
            Calidad
            TI
            Finanzas

            Contenido:
            {content}
            """);
    }

    public async Task<string> GenerateRecommendationsAsync(string content)
    {
        return await AskGemini(
            $"Genera tres recomendaciones para el siguiente contenido:\n{content}");
    }

    public async Task<string> AskAsync(string question, string context)
    {
        return await AskGemini(
            $"""
            Responde usando únicamente la información proporcionada.

            Información:
            {context}

            Pregunta:
            {question}
            """);
    }

    private async Task<string> AskGemini(string prompt)
    {
        var googleAI = new GoogleAI(_apiKey);

        var model = googleAI.GenerativeModel("gemini-2.5-flash");

        var response = await model.GenerateContent(prompt);

        return response.Text;
    }
}