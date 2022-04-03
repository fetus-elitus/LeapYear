using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.DataContext
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }
        public DbSet<Person> people { get; set; }
    }
}
