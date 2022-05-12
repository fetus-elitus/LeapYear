using Extensions;
using Interfaces;
using Models.EntityModels;
using Models.ViewModels;
using System.Security.Claims;

namespace Services;

public class PersonUserService : IPersonUserService
{
    private readonly IPersonRepository _personRepo;
    private readonly IUserRepository userRepo;

    public PersonUserService(IPersonRepository personRepository, IUserRepository userRepository)
    {
        _personRepo = personRepository;
        userRepo = userRepository;
    }

    public void AddEntry(Person person)
    {
        _personRepo.AddEntry(person);
    }

    public Person GetEntry(int id)
    {
        return _personRepo.GetEntry(id);
    }

    public PersonListViewModel GetLastAdded(Claim claim)
    {
        var people = _personRepo.GetLastAdded().ToModel(claim);
        PersonListViewModel result = new();
        result.People = people.ToList();
        return result;
    }

    public PersonListViewModel GetPeople()
    {
        var people = _personRepo.GetAllEntries().ToModel();
  
        PersonListViewModel result = new();
        
        result.People = people.ToList();
        result.Count = people.Count();
        return result;
    }

    public PersonListViewModel GetPeopleOfUser(Claim claim)
    {

        var user = userRepo.GetUser(claim.Value);

        PersonListViewModel result = new();      
        var people = _personRepo.GetPeopleWhere(person 
            => person.User == user) .
            ToModel(claim);

        result.People = people.ToList();
        return result;
    }

    public PersonListViewModel GetPeopleToday()
    {
        var people = _personRepo.GetEntriesFromToday().ToModel();
        PersonListViewModel result = new();

        result.People = people.ToList();
        result.Count = people.Count();
        return result;
    }

    public AppUser GetUser(Claim claim)
    {
        return (AppUser)userRepo.GetUser(claim?.Value);
    }

    public void RemoveEntry(Person person)
    {
        var p = _personRepo.GetEntry(person.PersonId);
        _personRepo.RemoveEntry(p);
    }
}
