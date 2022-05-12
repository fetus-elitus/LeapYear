using Microsoft.AspNetCore.Identity;
using Models.EntityModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces;

public interface IUserService
{
    public AppUser GetUser(Claim claim);
    public PersonListViewModel GetPeopleOfUser(Claim claim);
}
