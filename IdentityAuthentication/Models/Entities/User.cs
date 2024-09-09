using Microsoft.AspNetCore.Identity;

namespace IdentityAuthentication.Models.Entities
{
    public class User : IdentityUser
    {
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
    }
}
