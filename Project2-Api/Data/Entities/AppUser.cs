using Microsoft.AspNetCore.Identity;

namespace Project2_Api.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; } = new HashSet<Basket>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
