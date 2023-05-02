namespace range_ton_ricaud.Models
{
    public class ToolKeyword
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Tool>? Tools { get; set; }
    }
}
