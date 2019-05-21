using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace BLL
{
    public class UserService : IUserService
    {
        List<User> users = Datas.Users.userList;
        public bool Add(User model)
        {
            try
            {
                var newUser = new User();
                newUser.ID = model.ID;
                newUser.Name = model.Name;
                newUser.LastName = model.LastName;
                newUser.Age = model.Age;
                newUser.Email = model.Email;
                newUser.IdentityNo = model.IdentityNo;
                newUser.Sex= model.Sex;
                users.Add(newUser);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = users.FirstOrDefault(x => x.ID == id);
                users.Remove(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<User> GetAll()
        {
            return users;
        }

        public User GetByID(int id)
        {
            var user = users.FirstOrDefault(x => x.ID == id);
            return user;
        }

        public bool Update(int id,User model)
        {
            var user = users.FirstOrDefault(x => x.ID == id);
            if (user != null)
            {
                user.ID = model.ID;
                user.Name = model.Name;
                user.LastName = model.LastName;
                user.Age = model.Age;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
        
        
