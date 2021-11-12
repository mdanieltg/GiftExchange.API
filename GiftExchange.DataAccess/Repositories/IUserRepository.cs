using System.Collections.Generic;
using GiftExchange.DataAccess.Entities;

namespace GiftExchange.DataAccess
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(int userId);
        User Get(string email);
        void Add(User user);
        void Remove(User user);
        bool Exists(int userId);
        void Save();
    }
}
