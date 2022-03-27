using LeapYear.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace LeapYear.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public PersonYear PersonYear { get; set; }
        public bool IsValidated { get; set; } = false;
        public List<PersonYear> PersonYears { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPostYear()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data is not null)
                PersonYears = JsonConvert.DeserializeObject<List<PersonYear>>(Data);

            if(ModelState.IsValid)
            {
                if(PersonYear.Name.Where(x => "123456789".Contains(x)).Count() > 0)
                {
                    ModelState.AddModelError("PersonYear.Name", "Imiona nie mogą zawierać liczb");
                }
                else
                {
                    PersonYears.Add(PersonYear);
                    HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(PersonYears));
                    IsValidated = true;
                }
            }
            return Page();
            
        }
    }
}