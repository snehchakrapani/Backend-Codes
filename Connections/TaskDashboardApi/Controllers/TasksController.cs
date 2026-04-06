using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskDashboardApi.Data;
using TaskDashboardApi.Models;

namespace TaskDashboardApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks(int userId)
    {
        var tasks = await _context.Tasks
            .Where(t => t.UserId == userId)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();

        return Ok(tasks);
    }

    [HttpPost]
    public async Task<ActionResult<TaskItem>> AddTask(TaskItem task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return Ok(task);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTask(int id, TaskItem updatedTask)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return NotFound();

        task.Title = updatedTask.Title;
        task.Description = updatedTask.Description;
        task.Priority = updatedTask.Priority;
        task.Status = updatedTask.Status;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return NotFound();

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
