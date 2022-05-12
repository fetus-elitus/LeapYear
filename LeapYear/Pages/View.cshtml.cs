using Interfaces;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.ViewModels;

namespace LeapYear.Pages
{
    public class ViewModel : PageModel
    {
        private readonly IPersonUserService _personService;
        public PersonListViewModel Records { get; set; }
        public ViewModel(IPersonUserService personService)
        {
            _personService = personService;
        }
        public void OnGet()
        {
            Records = _personService.GetPeople();
        }
    }
}
