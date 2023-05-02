using System.ComponentModel.DataAnnotations;

namespace range_ton_ricaud.Models;

public class Tool
{
    public int Id { get; set; }

    [StringLength(80)]
    [Required]
    public string? Name { get; set; }

    [Display(Name = "Added At")]
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;

    [Display(Name = "Broken At")]
    public DateTime? BrokenAt { get; set; } = null!;

    public int GarageId { get; set; }
    public Garage? Garage { get; set; }

    public ICollection<ToolKeyword>? ToolKeywords { get; set; }
}