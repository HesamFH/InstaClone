using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InstaClone.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        public bool IsAdmin { get; set; }

        public string ProfilePic { get; set; }



        public IEnumerable<Posts> Posts { get; set; }
    }
}
