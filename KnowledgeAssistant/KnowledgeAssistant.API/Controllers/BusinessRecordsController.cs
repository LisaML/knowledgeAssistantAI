using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KnowledgeAssistant.API.Data;
using KnowledgeAssistant.API.Models;

namespace KnowledgeAssistant.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BusinessRecordsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<BusinessRecordsController> _logger;

    public BusinessRecordsController(
        ApplicationDbContext context,
        ILogger<BusinessRecordsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.BusinessRecords.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var record =
            await _context.BusinessRecords.FindAsync(id);

        if (record == null)
            return NotFound();

        return Ok(record);
    }
    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string term)
    {
        var results = await _context.BusinessRecords
            .Where(r =>
                r.Title.Contains(term) ||
                r.Content.Contains(term) ||
                r.Department.Contains(term))
            .ToListAsync();

        return Ok(results);
    }

    [HttpGet("filter")]
    public async Task<IActionResult> FilterByDepartment([FromQuery] string department)
    {
        var results = await _context.BusinessRecords
            .Where(r => r.Department == department)
            .ToListAsync();

        return Ok(results);
    }
    [HttpPost]
    public async Task<IActionResult> Create(
        BusinessRecord record)
    {_logger.LogInformation(
    "Creating business record with title {Title}",
    record.Title);
        _context.BusinessRecords.Add(record);

        await _context.SaveChangesAsync();

        return Ok(record);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        BusinessRecord record)
    {
        if (id != record.Id)
            return BadRequest();

        _context.Entry(record).State =
            EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {_logger.LogInformation(
    "Deleting business record with id {Id}",
    id);
        var record =
            await _context.BusinessRecords.FindAsync(id);

        if (record == null)
            return NotFound();

        _context.BusinessRecords.Remove(record);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}