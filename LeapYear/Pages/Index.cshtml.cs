using Data.DataContext;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.EntityModels;

namespace LeapYear.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPersonService _personService;
        public Person Person { get; set; }
        public bool IsValidated { get; set; } = false;

        public IndexModel(ILogger<IndexModel> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
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
                    _personService.AddEntry(Person);
                    IsValidated = true;
                }
            }
            return Page();
            
        }
    }
}