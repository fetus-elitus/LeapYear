using Data.DataContext;
using Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace LeapYear.Pages
{
    public class OstatnioSzukane : PageModel
    {
        private readonly PersonContext _db;
        public List<Person> People { get; set; }
        public OstatnioSzukane(PersonContext db)
        {
            _db = db;
            People = (from person in db.people
                     orderby person.DataRetrievedTime 
                     descending select person).ToList();
        }
        public void OnGet()
        {
            
        }  
        public void DeleteMember()
        {
            
        }
    }
}