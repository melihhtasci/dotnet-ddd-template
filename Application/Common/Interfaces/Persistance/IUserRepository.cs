using Domain;
using Domain.SeedWork;

namespace Application.Common.Interfaces.Persistance
{
    public interface IUserRepository : IRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}
