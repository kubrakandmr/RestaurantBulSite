using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantBul.Models
{
    public class Comment
    {
        public int CommentID { get; set; }

        [Display(Name = "İçerik")]
        public string Content { get; set; }

        [Display(Name = "Fotoğraf")]
        public string CommentPic { get; set; }

        [Display(Name = "Puan")]
        public int Point { get; set; }

        public int? PlaceID { get; set; }
        public virtual Place Place { get; set; }

       
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}