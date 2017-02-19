using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ZobShop.Models
{
    public class User : IdentityUser
    {
        public User() : base(string.Empty)
        {

        }

        public User(string username, string email, string name, string phoneNumber, string address)
        {
            this.UserName = username;
            this.Email = email;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
