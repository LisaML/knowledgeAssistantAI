using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KnowledgeAssistant.API.Data;
using KnowledgeAssistant.API.Models;
using KnowledgeAssistant.API.Services;

namespace KnowledgeAssistant.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AIController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IAIService _aiService;
    private readonly ILogger<AIController> _logger;

    public AIController(
        ApplicationDbContext context,
        IAIService aiService,
        ILogger<AIController> logger)
    {
        _context = context;
        _aiService = aiService;
        _logger = logger;
    }

    [HttpPost("analyze/{recordId}")]
    public async Task<IActionResult> Analyze(int recordId)
    {
        _logger.LogInformation(
            "Analyzing record {RecordId}",
            recordId);

        var record = await _context.BusinessRecords
            .FirstOrDefaultAsync(r => r.Id == recordId);

        if (record == null)
            return NotFound();

        var analysis = new AIAnalysis
        {
            BusinessRecordId = record.Id,

            Summary =
                await _aiService.GenerateSummaryAsync(
                    record.Content),

            Classification =
                await _aiService.ClassifyAsync(
                    record.Content),

            Recommendations =
                await _aiService.GenerateRecommendationsAsync(
                    record.Content)
        };

        _context.AIAnalyses.Add(analysis);

        await _context.SaveChangesAsync();

        return Ok(analysis);
    }

    [HttpPost("ask")]
    public async Task<IActionResult> Ask(
        AskRequest request)
    {
        _logger.LogInformation("AI question received");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var records = await _context.BusinessRecords.ToListAsync();

        var context = string.Join("\n", records.Select(r =>
            $"Título: {r.Title}. Departamento: {r.Department}. Contenido: {r.Content}"));

        var answer =
            await _aiService.AskAsync(
                request.Question,
                context);

        return Ok(new
        {
            question = request.Question,
            answer
        });
    }
}