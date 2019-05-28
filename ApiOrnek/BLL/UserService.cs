using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Core;
using DAL;
using DAL.Context;

namespace BLL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ProjectContext db;

        public UserService()
        {
            db = new ProjectContext();
            _userRepository = new EFRepository();
        }

        public bool Add(User model)
        {
            try
            {
                _userRepository.Add(model);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ChangePassword(int id, ChangePasswordModel model)
        {
            if (model != null)
            {
                _userRepository.ChangePassword(id, model);
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
                _userRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ForgotPassword(int id,string email)
        {
            _userRepository.ForgotPassword(id, email);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetByID(int id)
        {
            return _userRepository.GetByID(id);
        }

        public bool RegisterUser(RegisterModel model)
        {
            try
            {
                if (model != null)
                {
                    _userRepository.RegisterUser(model);
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
            if (model != null)
            {
                _userRepository.Update(id, model);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateCredentials(string email, string password)
        {
            var user = _userRepository.GetAll().Any(x => x.Email == email && x.Password == password);
            if (user)
            {
                _userRepository.ValidateCredentials(email,password);
                return true;
            }
            return false;
        }
    }
}


