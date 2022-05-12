using Models.EntityModels;
using Models.ViewModels;
using System.Security.Claims;

namespace Extensions;

public static  class BookViewModelExtensions
{
    public static IQueryable<PersonViewModel> ToModel(this IQueryable<Person> source, Claim? claim = null)
    {
        string claimId = claim?.Value;

        return source.Select(person => new PersonViewModel()
        {
            Id = person.PersonId,
            FullName = person.Name + " " + person.LastName,
            IsUsers = (person.User != null ? person.User.Id == claimId : false)
        }); ;
    }
}
