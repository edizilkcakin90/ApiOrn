using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core
{
    public class RegisterModel : User
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string lastName { get; set; }
        public short age { get; set; }
        [Required]
        public string identityNo { get; set; }
        [Required]
        public string eMail { get; set; }
        public char  sex { get; set; }
        [Required]
        public string password { get; set; }
    }
}
