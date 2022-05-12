using Data.DataContext;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.EntityModels;

namespace LeapYear.Pages
{
    [BindProperties]
    public class UsunModel : PageModel
    {
        public List<Person> People;
        private readonly IPersonUserService _personUserService;
        public Person Person { get; set; }
        public UsunModel(IPersonUserService personUserService)
        {
            _personUserService = personUserService;
        }
        public void OnGet(int Id)
        {
            Person = _personUserService.GetEntry(Id);
        }  
        public IActionResult OnPost()
        {
        
            _personUserService.RemoveEntry(Person);
            TempData["Success"] = "Osoba została usunięta pomyślnie";

            return RedirectToPage("OstatnioSzukane");
        }
        
    }
}