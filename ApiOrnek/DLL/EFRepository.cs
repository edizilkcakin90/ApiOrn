using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Context;

namespace DAL
{
    public class EFRepository : IUserRepository
    {
        private readonly ProjectContext db;

        public EFRepository()
        {
            db = new ProjectContext();
        }
        public bool Add(User model)
        {
            try
            {
                var newUser = new User
                {
                    ID = model.ID,
                    Name = model.Name,
                    LastName = model.LastName,
                    Age = model.Age,
                    Email = model.Email,
                    IdentityNo = model.IdentityNo,
                    Sex = model.Sex,
                    Password = model.Password
                };
                db.Users.Add(newUser);
                db.SaveChanges();
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
                var user = db.Users.FirstOrDefault(x => x.ID == id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User GetByID(int id)
        {
            return db.Users.FirstOrDefault(x => x.ID == id);
        }

        public bool Update(int id, User model)
        {
            var user = db.Users.FirstOrDefault(x => (x.ID == id));
            if (user != null)
            {
                user.ID = model.ID;
                user.Name = model.Name;
                user.LastName = model.LastName;
                user.Age = model.Age;
                user.Email = model.Email;
                user.IdentityNo = model.IdentityNo;
                user.Sex = model.Sex;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
