using Data.DataContext;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.EntityModels;
using System.Linq.Expressions;
using System.Security.Claims;

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

    public Person GetEntry(int id)
    {
        return _context.People.Find(id);
    }

    public void RemoveEntry(Person person)
    {
        _context.People.Remove(person);
        _context.SaveChanges();
    }
    public IQueryable<Person> GetPeopleWhere(Func<Person, bool> predicate)
    {
        var result =  _context.People.Where(predicate).AsQueryable();
        return result;
    }

    public IQueryable<Person> GetLastAdded()
    {
        var result =  _context.People.OrderByDescending(p => p.DataRetrievedTime).Take(20);
        return result;
    }
}
