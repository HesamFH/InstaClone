using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InstaClone.Models
{
    public class Follow
    {
        [Required]
        public int FollowerId { get; set; }

        [Required]
        public int FollowedUserId { get; set; }
    }
}
