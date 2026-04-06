namespace TaskDashboardApi.Models;

public class AppUser
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";

    public List<TaskItem> Tasks { get; set; } = new();
    public List<NoteItem> Notes { get; set; } = new();
}
