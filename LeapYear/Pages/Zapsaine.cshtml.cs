using LeapYear.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LeapYear.Pages
{
    public class ZapisaneModel : PageModel
    {
        public PersonYear PersonYear { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                int breakp= 5;
            }
            return Page();
        }

        public bool CheckIfLeapYear(int year)
        {
            if (year % 4 == 0)
                return false;
            else if (year % 100 != 0)
                return true;
            else if (year % 400 != 0)
                return false;
            else
                return true;
        }

    }
}