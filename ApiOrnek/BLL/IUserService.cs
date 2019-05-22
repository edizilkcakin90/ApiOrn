using Core;
using DAL;

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
