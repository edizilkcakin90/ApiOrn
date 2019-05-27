using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Core;

namespace DAL
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> users = Datas.Users.userList;
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
                users.Add(newUser);
                return true;
            }
            catch (Exception)
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
                var user = users.FirstOrDefault(x => x.ID == id);
                users.Remove(user);
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
            MailMessage message = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            message.To.Add(forgotUser.Email.ToString());
            message.Subject = "Password Recovery";
            message.From = new System.Net.Mail.MailAddress("ediz.ilkcakin@gmail.com");
            message.Body = "Your Password is :" + forgotUser.Password;
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com"
            };

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
            SmtpServer.EnableSsl = true;

            smtp.Send(message);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User GetByID(int id)
        {
            return users.FirstOrDefault(x => x.ID == id);
        }

        public bool RegisterUser(RegisterModel model)
        {
            try
            {
                var user = GetAll().FirstOrDefault(x => x.ID == model.ID);
                if (user != model)
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
                    users.Add(newUser);                    
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

        public bool ValidateCredentials(string email, string password)
        {
            var user = GetAll().Any(x => x.Email == email && x.Password == password);
            if (user)
            {
                return true;
            }
            return false;
        }
    }
}
