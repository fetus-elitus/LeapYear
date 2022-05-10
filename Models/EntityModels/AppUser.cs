using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels
{
    public class AppUser : IdentityUser
    {
        public ICollection<Person>? People { get; set; }
    }
}
