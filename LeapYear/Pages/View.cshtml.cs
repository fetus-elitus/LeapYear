using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.ViewModels;

namespace LeapYear.Pages
{
    public class ViewModel : PageModel
    {
        private readonly IPersonService _personService;
        public PersonListViewModel Records { get; set; }
        public ViewModel(IPersonService personService)
        {
            _personService = personService;
        }
        public void OnGet()
        {
            Records = _personService.GetPeople();
        }
    }
}
