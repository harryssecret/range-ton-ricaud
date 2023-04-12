using System.ComponentModel.DataAnnotations;

namespace range_ton_ricaud.Models;

public class Tool
{
    public int Id { get; set; }

    [StringLength(80)]
    [Required]
    public string? Name { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime AddedAt { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? BrokenAt { get; set; }

    public int GarageId { get; set; }
    public Garage Garage { get; set; } = null!;
}