﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class PostLike
    {
        [Key]
        public int PostLikeId { get; set; }        
        public DateTime LikeTime { get; set; }

        //User ile ilişkilendirilecek.        
        public int UserId { get; set; }
        public User PostLiker { get; set; }

        //Post ile ilişkilendirilecek.
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}