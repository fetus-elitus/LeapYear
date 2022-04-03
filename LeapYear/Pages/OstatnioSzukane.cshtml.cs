using Data.DataContext;
using Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace LeapYear.Pages
{
    public class OStatnioSzukane : PageModel
    {
        private readonly PersonContext _db;
        public List<Person> People = new();
        public OStatnioSzukane(PersonContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            if(Data is not null)
                People = JsonConvert.DeserializeObject<List<Person>>(Data);
        }  
        public void DeleteMember()
        {
            
        }
    }
}