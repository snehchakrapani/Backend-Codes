using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskDashboardApi.Data;
using TaskDashboardApi.Models;

namespace TaskDashboardApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly AppDbContext _context;

    public NotesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<IEnumerable<NoteItem>>> GetNotes(int userId)
    {
        var notes = await _context.Notes
            .Where(n => n.UserId == userId)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();

        return Ok(notes);
    }

    [HttpPost]
    public async Task<ActionResult<NoteItem>> AddNote(NoteItem note)
    {
        _context.Notes.Add(note);
        await _context.SaveChangesAsync();

        return Ok(note);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteNote(int id)
    {
        var note = await _context.Notes.FindAsync(id);

        if (note == null)
            return NotFound();

        _context.Notes.Remove(note);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
