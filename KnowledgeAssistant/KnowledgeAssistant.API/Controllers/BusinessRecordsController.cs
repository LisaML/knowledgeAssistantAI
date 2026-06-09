using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KnowledgeAssistant.API.Data;
using KnowledgeAssistant.API.Models;

namespace KnowledgeAssistant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BusinessRecordsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BusinessRecordsController(
        ApplicationDbContext context)
    {
        _context = context;
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

    [HttpPost]
    public async Task<IActionResult> Create(
        BusinessRecord record)
    {
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
    {
        var record =
            await _context.BusinessRecords.FindAsync(id);

        if (record == null)
            return NotFound();

        _context.BusinessRecords.Remove(record);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}