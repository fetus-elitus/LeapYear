using Data.DataContext;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.EntityModels;
using Models.ViewModels;

namespace LeapYear.Pages;

[Authorize]
public class OstatnioSzukane : PageModel
{
    private readonly IPersonService _personService;
    public PersonListViewModel Records { get; set; }
    public OstatnioSzukane(IPersonService personService)
    {
      _personService = personService;
    }
    public void OnGet()
    {
        Records = _personService.GetPeopleToday();
    }  
   
}
