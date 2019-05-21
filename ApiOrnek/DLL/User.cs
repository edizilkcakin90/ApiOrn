using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class User
    {
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
    }
}
