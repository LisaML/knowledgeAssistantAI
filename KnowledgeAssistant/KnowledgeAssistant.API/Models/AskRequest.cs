using System.ComponentModel.DataAnnotations;

namespace KnowledgeAssistant.API.Models;

public class AskRequest
{
    [Required]
    public string Question { get; set; } = string.Empty;
}