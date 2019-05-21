using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace DAL
{
    public class InMemoryUserRepository : IUserRepository
    {
        List<User> users = Datas.Users.userList;
        public bool Add(User model)
        {
            try
            {
                var user = users.Where(x => x.ID == model.ID);
                var newUser = new User();
                newUser.ID = model.ID;
                newUser.Name = model.Name;
                newUser.LastName = model.LastName;
                newUser.Age = model.Age;
                newUser.Email = model.Email;
                newUser.IdentityNo = model.IdentityNo;
                newUser.Sex = model.Sex;
                newUser.Password = model.Password;
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

        public bool Update(int id, User model)
        {
            var user = users.FirstOrDefault(x => (x.ID == id));
            if (user != null)
            {
                user.ID = model.ID;
                user.Name = model.Name;
                user.LastName = model.LastName;
                user.Age = model.Age;
                user.Email = model.Email;
                user.IdentityNo = model.IdentityNo;
                user.Sex = model.Sex;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
