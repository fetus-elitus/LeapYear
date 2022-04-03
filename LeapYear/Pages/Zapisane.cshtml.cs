using Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace LeapYear.Pages
{
    public class ZapisaneModel : PageModel
    {
        public List<Person> People = new();
        public Person Person { get; set; }
  
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data is not null)
                People = JsonConvert.DeserializeObject<List<Person>>(Data);
        }  
    }
}