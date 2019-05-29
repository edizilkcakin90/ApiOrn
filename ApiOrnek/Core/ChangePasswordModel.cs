namespace Core
{
    public class ChangePasswordModel:User
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }        
    }
}
