namespace KnowledgeAssistant.API.Models;

public class AIAnalysis
{
    public int Id { get; set; }

    public int BusinessRecordId { get; set; }

    public string Summary { get; set; } = string.Empty;

    public string Classification { get; set; } = string.Empty;

    public string Recommendations { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public BusinessRecord? BusinessRecord { get; set; }
}