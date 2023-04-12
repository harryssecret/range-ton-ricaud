namespace range_ton_ricaud.Models;

public class Garage
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; } = null;
    public string CityName { get; set; }

    public ICollection<Tool> Tools { get; }
}