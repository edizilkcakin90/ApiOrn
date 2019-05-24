﻿using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class User
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public short Age { get; set; }
        public string Email { get; set; }
        public string IdentityNo { get; set; }
        public char Sex { get; set; }
        public string Password { get; set; }
    }
}
