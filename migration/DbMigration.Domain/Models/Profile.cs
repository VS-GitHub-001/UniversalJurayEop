 using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigration.Domain.Models
{
    public class Profile : IdentityUser
    {
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get;set; }
        //public List<RefreshToken> RefreshTokens { get; set; }
        //public bool OwnsToken(string token)
        //{
        //    return this.RefreshTokens?.Find(x => x.Token == token) != null;
        //}
    }
}
