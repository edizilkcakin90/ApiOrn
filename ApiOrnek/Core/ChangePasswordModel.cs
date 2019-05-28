namespace Core
{
    public class ChangePasswordModel:User
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }        
    }
}
