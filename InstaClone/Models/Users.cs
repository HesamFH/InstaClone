using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaClone.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime RegisterDate { get; set; }



        public IEnumerable<Posts> Posts { get; set; }
    }
}
