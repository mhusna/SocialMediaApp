﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [StringLength(100)]
        public string Content { get; set; }

        public DateTime CommentTime { get; set; }

        //Post ile ilişkilendirilecek.
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        //User ile ilişkilendirilecek.
        public int UserId { get; set; }
        public virtual User Commentor { get; set; }

        //Kendiyle ilişkilenecek.KENDİNE ÇOK TABLO ÖĞREN TYAP !!!!!!!!
        [ForeignKey("ParentComment")]
        public int ParentCommentId { get; set; }
        public virtual Comment ParentComment { get; set; }
    }
}
