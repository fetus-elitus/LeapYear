using Models.EntityModels;
using Models.ViewModels;

namespace Extensions;

public static  class BookViewModelExtensions
{
    public static IQueryable<PersonViewModel> ToModel(this IQueryable<Person> source)
    {
        return source.Select(person => new PersonViewModel()
        {
            Id = person.PersonId,
            FullName = person.Name + " " + person.LastName
        });
    }
}
