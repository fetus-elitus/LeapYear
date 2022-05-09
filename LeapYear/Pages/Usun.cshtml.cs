using Data.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.EntityModels;

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
            Person = _db.People.Find(Id);
        }  
        public IActionResult OnPost()
        {
        
/*
            var person = _db.People.Find(Person.PersonId);

            _db.People.Remove(person);
            _db.SaveChanges();
            People?.RemoveAll(p => p.PersonId == person.PersonId);
            TempData["Success"] = "Osoba została usunięta pomyślnie";
*/
            return RedirectToPage("OstatnioSzukane");
        }
        
    }
}