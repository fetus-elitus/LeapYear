using Microsoft.AspNetCore.Identity;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces;

public interface IUserRepository
{
    public IdentityUser GetUser(string UserId);
}
