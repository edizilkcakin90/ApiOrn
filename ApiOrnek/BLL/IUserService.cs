using System;
using System.Collections.Generic;
using System.Text;
using Core;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace BLL
{
    public interface IUserService
    {
        bool RegisterUser(RegisterModel model);
        bool ChangePassword(int id, ChangePasswordModel model);
        bool ValidateCredentials(string email, string password);
        void ForgotPassword(int id,string email);
    }
}
