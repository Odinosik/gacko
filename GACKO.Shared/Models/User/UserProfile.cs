using Microsoft.AspNetCore.Identity;
using System;

namespace GACKO.Shared.Models.User
{
    public class UserProfile : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

