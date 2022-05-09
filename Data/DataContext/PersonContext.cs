using Microsoft.EntityFrameworkCore;
using Models.EntityModels;

namespace Data.DataContext
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }
        public DbSet<Person> People { get; set; }
    }
}
