using Data.DataContext;
using Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PersonContext _db;
        public UserRepository(PersonContext db)
        {
            _db = db;
        }

        public IdentityUser GetUser(string userId)
        {
            return _db.Users.Find(userId);
        }
    }
}
