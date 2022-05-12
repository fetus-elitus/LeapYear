using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.EntityModels;
using System.Security.Claims;

namespace LeapYear.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPersonUserService _personUserService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public Person Person { get; set; }
        public bool IsValidated { get; set; } = false;

        public IndexModel(ILogger<IndexModel> logger, IPersonUserService personUserService, UserManager<AppUser> user,
            SignInManager<AppUser> signIn)
        {
            _logger = logger;
            _personUserService = personUserService;
            _userManager = user;
            _signInManager = signIn;
            
        }
        
        public void OnGet()
        {

        }
        public IActionResult OnPostYear()
        {
           
            if (ModelState.IsValid)
            {
                if (Person.Name.Where(x => "123456789".Contains(x)).Count() > 0 )
                {
                    ModelState.AddModelError("Person.Name", "Imiona nie mogą zawierać liczb");
                }
                else if(Person?.LastName?.Where(x => "123456789".Contains(x)).Count() > 0)
                {
                    ModelState.AddModelError("Person.LastName", "Nazwiska nie mogą zawierać liczb");
                }
                else
                {
                    Person.CheckIfLeapYear();
                    Person.DataRetrievedTime = DateTime.Now;

                    var claimsIdentity = (ClaimsIdentity)User.Identity;
                    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                    Person.User = _personUserService.GetUser(claim);
                    _personUserService.AddEntry(Person);
                    
                    IsValidated = true;
                }
            }
            return Page();
            
        }
    }
}