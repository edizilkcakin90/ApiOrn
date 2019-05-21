using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace DAL
{
    public interface IUserRepository
    {
        bool Add(User model);

        bool Update(int id, User model);

        bool Delete(int id);

        List<User> GetAll();

        User GetByID(int id);
    }
}
