using LeapYear.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace LeapYear.Pages
{
    public class ZapisaneModel : PageModel
    {
        public List<PersonYear> people = new();
        public PersonYear PersonYear { get; set; }
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            if(Data is not null)
                people = JsonConvert.DeserializeObject<List<PersonYear>>(Data);
        }  
    }
}