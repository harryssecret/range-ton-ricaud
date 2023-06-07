using Microsoft.AspNetCore.Identity;

namespace range_ton_ricaud.Models;

public class ApplicationUser : IdentityUser
{
    public ICollection<Garage> Garages { get; set; } = new List<Garage>();
}