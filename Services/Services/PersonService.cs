using Data.Repository;
using Extensions;
using Interfaces;
using Models.EntityModels;
using Models.ViewModels;

namespace Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _repo;

    public PersonService(IPersonRepository repository)
    {
        _repo = repository;
    }

    public void AddEntry(Person person)
    {
        _repo.AddEntry(person);
    }
    public PersonListViewModel GetPeople()
    {
        var people = _repo.GetAllEntries().ToModel();
        PersonListViewModel result = new();
        
        result.People = people.ToList();
        result.Count = people.Count();
        return result;
    }

    public PersonListViewModel GetPeopleToday()
    {
        var people = _repo.GetEntriesFromToday().ToModel();
        PersonListViewModel result = new();

        result.People = people.ToList();
        result.Count = people.Count();
        return result;
    }
}
