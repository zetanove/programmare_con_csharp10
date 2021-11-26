using System.ComponentModel.DataAnnotations;

namespace TodoRazorPages.Models;

public class TodoActivity
{
	public Guid Id { get; set; }
	[Required]
	public string Title { get; set; }
	public DateTime? Date { get; set; }
	public string? Notes { get; set; }
	public bool Completed { get; set; }
}
	