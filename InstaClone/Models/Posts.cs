using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaClone.Models
{
    public class Posts
    {
        public int PostId { get; set; }

        public int UserId { get; set; }


        public Users User { get; set; }
    }
}
