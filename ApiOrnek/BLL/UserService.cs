using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Core;

namespace BLL
{
    public class UserService : IUserService
    {
        List<User> users = Datas.Users.userList;
        public void ChangePassword(ChangePasswordModel model)
        {
            //doldur
        }

        public void ForgotPassword(int id,string email)
        {
            
            var forgotUser = users.FirstOrDefault(x => x.Email == email);
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
                var user = users.Where(x => x.ID == model.ID);
                if (user != model)
                {
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
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ValidateCredentials(string email, string password)
        {
            //doldur
        }
    }
}


