using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Core;
using DAL.Context;

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
                    Name = model.Name,
                    LastName = model.LastName,
                    Age = model.Age,
                    Email = model.Email,
                    IdentityNo = model.IdentityNo,
                    Sex = model.Sex,
                    Password = model.Password
                };
                db.Set<User>().Add(newUser);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false; 
            }
        }

        public bool ChangePassword(int id, ChangePasswordModel model)
        {
            var user = GetAll().FirstOrDefault(x => (x.ID == id));
            if (user != null)
            {
                user.Password = model.NewPassword;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.FirstOrDefault(x => x.ID == id);
                db.Set<User>().Remove(user);
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
            return db.Set<User>().ToList();
        }

        public User GetByEmail(string email)
        {
            return db.Set<User>().FirstOrDefault(x => x.Email == email);
        }

        public User GetByID(int id)
        {
            return db.Set<User>().FirstOrDefault(x => x.ID == id);
        }

        public bool Update(int id, User model)
        {
            var user = db.Set<User>().FirstOrDefault(x => (x.ID == id));
            if (user != null)
            {
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
