using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KnowledgeAssistant.API.Data;
using KnowledgeAssistant.API.Models;
using KnowledgeAssistant.API.Services;

namespace KnowledgeAssistant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AIController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IAIService _aiService;

    public AIController(ApplicationDbContext context, IAIService aiService)
    {
        _context = context;
        _aiService = aiService;
    }

    [HttpPost("analyze/{recordId}")]
    public async Task<IActionResult> Analyze(int recordId)
    {
        var record = await _context.BusinessRecords.FindAsync(recordId);

        if (record == null)
            return NotFound("Registro no encontrado");

        var summary = await _aiService.GenerateSummaryAsync(record.Content);
        var classification = await _aiService.ClassifyAsync(record.Content);
        var recommendations = await _aiService.GenerateRecommendationsAsync(record.Content);

        var analysis = new AIAnalysis
        {
            BusinessRecordId = record.Id,
            Summary = summary,
            Classification = classification,
            Recommendations = recommendations
        };

        _context.AIAnalyses.Add(analysis);
        await _context.SaveChangesAsync();

        return Ok(analysis);
    }

    [HttpPost("ask")]
    public async Task<IActionResult> Ask([FromBody] AskRequest request)
    {
        var records = await _context.BusinessRecords.ToListAsync();

        var context = string.Join("\n", records.Select(r =>
            $"Título: {r.Title}. Departamento: {r.Department}. Contenido: {r.Content}"));

        var answer = await _aiService.AskAsync(request.Question, context);

        return Ok(new
        {
            question = request.Question,
            answer
        });
    }
}

public class AskRequest
{
    public string Question { get; set; } = string.Empty;
}