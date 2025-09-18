using Microsoft.AspNetCore.Identity;

namespace AgriEnergyConnect.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int? FarmerId { get; set; }
        public Farmer? Farmer { get; set; }
    }
}
