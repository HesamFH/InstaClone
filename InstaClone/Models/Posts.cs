﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstaClone.Models
{
    public class Posts
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public int UserId { get; set; }


        public Users User { get; set; }
    }
}
