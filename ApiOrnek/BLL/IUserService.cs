using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace BLL
{
    public interface IUserService
    {
        bool Add(User model);

        bool Update(int id,User model);

        bool Delete(int id);

        List<User> GetAll();

        User GetByID(int id);
    }
}
