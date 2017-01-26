using Microsoft.AspNet.Identity.EntityFramework;

namespace ZobShop.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
    }
}
