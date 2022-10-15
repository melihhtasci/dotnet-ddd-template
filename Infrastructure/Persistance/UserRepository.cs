using Application.Common.Interfaces.Persistance;
using Domain;

namespace Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        public static List<User> users = new();
        public void Add(User user)
        {
            users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return users.SingleOrDefault(u => u.Email == email);
        }

        public Task<int> SaveChangesAsync()
        {
            return Task.FromResult(1);  // just for now throw new NotImplementedException(); 
        }
    }
}
