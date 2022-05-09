using Models.EntityModels;
using Models.ViewModels;

namespace Interfaces;
public interface IPersonService
{
    public void AddEntry(Person person);
    public PersonListViewModel GetPeople();
    public PersonListViewModel GetPeopleToday();
}
