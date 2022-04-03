using Data.DataContext;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace LeapYear.Pages
{
    [BindProperties]
    public class UsunModel : PageModel
    {
        public List<Person> People;
        private readonly PersonContext _db;
        public Person Person { get; set; }
        public UsunModel(PersonContext db)
        {
            _db = db;
        }
        public void OnGet(int Id)
        {
            Person = _db.people.Find(Id);
        }  
        public IActionResult OnPost()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data is not null)
                People = JsonConvert.DeserializeObject<List<Person>>(Data);

            var person = _db.people.Find(Person.PersonId);
            if(person is not null)
            {
                _db.people.Remove(person);
                _db.SaveChanges();
                People.RemoveAll(p => p.PersonId == person.PersonId);
                HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(People));
                TempData["Success"] = "Osoba została usunięta pomyślnie";
            }

            return RedirectToPage("OstatnioSzukane");
        }
        
    }
}