using Models.EntityModels;
using System.Linq.Expressions;

namespace Interfaces;

public interface IPersonRepository
{
    public void AddEntry(Person person);
    public IQueryable<Person> GetAllEntries();
    public IQueryable<Person> GetEntriesFromToday();
    public Person GetEntry(int id);
    public void RemoveEntry(Person person);
    public IQueryable<Person> GetPeopleWhere(Func<Person, bool> predicate);
    public IQueryable<Person> GetLastAdded();


}
