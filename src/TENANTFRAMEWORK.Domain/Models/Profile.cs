using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TENANTFRAMEWORK.Domain.Models
{
    public class Profile : IdentityUser
    {
        public string Description { get; set; }
    }
}
