using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.EntityModels;
using Models.ViewModels;
using System.Security.Claims;

namespace LeapYear.Pages;

[Authorize]
public class OstatnioSzukane : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IPersonUserService _personUserService;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    public PersonListViewModel Records { get; set; }


    public OstatnioSzukane(ILogger<IndexModel> logger, IPersonUserService personUserService, UserManager<AppUser> user,
        SignInManager<AppUser> signIn)
    {
        _logger = logger;
        _personUserService = personUserService;
        _userManager = user;
        _signInManager = signIn;

    }

    public void OnGet()
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        Records = _personUserService.GetLastAdded(claim);
    }  
   
}
