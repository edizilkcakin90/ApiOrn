using System.Collections.Generic;
using Core;

namespace DAL
{
    public interface IUserRepository
    {
        bool Add(User model);
        bool Update(int id, User model);
        bool Delete(int id);
        IEnumerable<User> GetAll();
        User GetByID(int id);
        bool ChangePassword(int id, ChangePasswordModel model);
        User GetByEmail(string email);
    }
}
