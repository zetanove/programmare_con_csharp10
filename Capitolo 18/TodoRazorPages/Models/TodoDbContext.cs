using Microsoft.EntityFrameworkCore;
namespace TodoRazorPages.Models;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    { }

    public DbSet<TodoActivity> Activities { get; set; }
}