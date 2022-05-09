using Data.DataContext;
using Interfaces;
using Models.EntityModels;

namespace Data.Repository;

public class PersonRepository : IPersonRepository
{
    private readonly PersonContext _context;
    public PersonRepository(PersonContext context)
    {
        _context = context;
    }
    public void AddEntry(Person person)
    {
        _context.Add(person);
        _context.SaveChanges();
    }

    public IQueryable<Person> GetAllEntries()
    {
        return from person in _context.People select person;
    }

    public IQueryable<Person> GetEntriesFromToday()
    {
        return from person in _context.People where person
               .DataRetrievedTime.Date == DateTime.Today.Date 
               select person;
    }
}
