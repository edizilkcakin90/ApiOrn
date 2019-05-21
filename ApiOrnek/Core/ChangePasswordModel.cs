using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ChangePasswordModel
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }        
    }
}
