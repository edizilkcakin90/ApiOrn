using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Core;
using DAL;

namespace BLL
{
    public class UserService : IUserService
    {
        InMemoryUserRepository userRepository;

        public UserService()
        {
            userRepository = new InMemoryUserRepository();
        }
        public bool ChangePassword(int id, ChangePasswordModel model)
        {
            var user = userRepository.GetAll().FirstOrDefault(x => (x.ID == id));
            if (user != null)
            {
                user.Password = model.NewPassword;
                return true;
            }
            else
            {
                user.Password = model.OldPassword;
                return false;
            }
        }

        public void ForgotPassword(int id,string email)
        {
            
            var forgotUser = userRepository.GetAll().FirstOrDefault(x => x.Email == email);
            MailMessage message = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            message.To.Add(forgotUser.Email.ToString());
            message.Subject = "Password Recovery";
            message.From = new System.Net.Mail.MailAddress("ediz.ilkcakin@gmail.com");
            message.Body = "Your Password is :" + forgotUser.Password;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
            SmtpServer.EnableSsl = true;

            smtp.Send(message);
        }

        public bool RegisterUser(RegisterModel model)
        {
            try
            {
                var user = userRepository.GetAll().FirstOrDefault(x => x.ID == model.ID);
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
                    userRepository.GetAll().Add(newUser);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ValidateCredentials(string email, string password)
        {
            var user = userRepository.GetAll().Any(x => x.Email == email && x.Password == password);
            if (user)
            {
                return true;
            }
            return false;
        }
    }
}


