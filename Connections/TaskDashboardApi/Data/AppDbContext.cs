using Microsoft.EntityFrameworkCore;
using TaskDashboardApi.Models;

namespace TaskDashboardApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
    public DbSet<NoteItem> Notes => Set<NoteItem>();
}
