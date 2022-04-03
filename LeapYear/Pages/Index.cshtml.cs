using Data.DataContext;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace LeapYear.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PersonContext _db;
        public Person Person { get; set; }
        public bool IsValidated { get; set; } = false;
        public List<Person> People { get; set; }

        public IndexModel(ILogger<IndexModel> logger, PersonContext db)
        {
            _logger = logger;
            _db = db;
        }
        
        public void OnGet()
        {
        }
        public IActionResult OnPostYear()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data is not null)
                People = JsonConvert.DeserializeObject<List<Person>>(Data);

            if (ModelState.IsValid)
            {
                if (Person.Name.Where(x => "123456789".Contains(x)).Count() > 0 )
                {
                    ModelState.AddModelError("Person.Name", "Imiona nie mogą zawierać liczb");
                }
                else if(Person.LastName.Where(x => "123456789".Contains(x)).Count() > 0)
                {
                    ModelState.AddModelError("Person.LastName", "Nazwiska nie mogą zawierać liczb");
                }
                else
                {
                    Person.CheckIfLeapYear();
                    Person.DataRetrievedTime = DateTime.Now;
                    _db.Add(Person);
                    _db.SaveChanges();
                    People.Add(Person);
                    HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(People));
                    IsValidated = true;
                }
            }
            return Page();
            
        }
    }
}