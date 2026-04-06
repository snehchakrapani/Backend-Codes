namespace TaskDashboardApi.Models;

public class NoteItem
{
    public int Id { get; set; }
    public string Text { get; set; } = "";
    public int Color { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }
    public AppUser? User { get; set; }
}
