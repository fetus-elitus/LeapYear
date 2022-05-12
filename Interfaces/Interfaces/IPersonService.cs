using Models.EntityModels;
using Models.ViewModels;
using System.Security.Claims;

namespace Interfaces;
public interface IPersonService
{
    public void AddEntry(Person person);
    public PersonListViewModel GetPeople();
    public PersonListViewModel GetPeopleToday();
    public void RemoveEntry(Person person);
    public Person GetEntry(int id);
    public PersonListViewModel GetLastAdded(Claim claim);
    
}
