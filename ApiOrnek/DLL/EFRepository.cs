﻿using System;
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

        public void ForgotPassword(int id, string email)
        {
            var forgotUser = GetAll().FirstOrDefault(x => x.Email == email);
            SendMail(forgotUser);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Set<User>().ToList();
        }

        public User GetByID(int id)
        {
            return db.Set<User>().FirstOrDefault(x => x.ID == id);
        }

        public bool RegisterUser(RegisterModel model)
        {
            try
            {
                var user = GetAll().Any(x => x.ID == model.regId);
                if (user)
                {
                    Add(model);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
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

        public bool ValidateCredentials(string email, string password)
        {
            var user = GetAll().Any(x => x.Email == email && x.Password == password);
            if (user)
            {
                return true;
            }
            return false;
        }

        public void SendMail(User model)
        {
            MailMessage message = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            message.To.Add(model.Email.ToString());
            message.Subject = "Password Recovery";
            message.From = new System.Net.Mail.MailAddress("ediz.ilkcakin@gmail.com");
            message.Body = "Your Password is :" + model.Password;
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com"
            };

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
            SmtpServer.EnableSsl = true;

            smtp.Send(message);
        }
    }
}
