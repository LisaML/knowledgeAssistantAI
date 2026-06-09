namespace KnowledgeAssistant.API.Models;

public class AIAnalysis
{
    public int Id { get; set; }

    public int BusinessRecordId { get; set; }

    public string Summary { get; set; } = "";

    public string Classification { get; set; } = "";

    public string Recommendations { get; set; } = "";
}