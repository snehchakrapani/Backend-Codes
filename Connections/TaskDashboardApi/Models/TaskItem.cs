namespace TaskDashboardApi.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string? Description { get; set; }
    public string Priority { get; set; } = "medium";
    public string Status { get; set; } = "pending";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }
    public AppUser? User { get; set; }
}
