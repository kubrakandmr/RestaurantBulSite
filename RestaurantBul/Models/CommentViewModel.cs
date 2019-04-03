using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static RestaurantBul.Enums.Enums;

namespace RestaurantBul.Models
{
    public class CommentViewModel
    {
       
        public string Content { get; set; }

        public string CommentPic { get; set; }
        public int PlaceID { get; set; }

        public int Point { get; set; }

        public string PlaceName { get; set; }

       
        public string MenuPic { get; set; }
        public CategoryName CategoryName { get; set; }

   
        public string Phone { get; set; }

       
        public string Address { get; set; }

   
        public string County { get; set; }


        public string City { get; set; }

  
        public string OpenTime { get; set; }

 
        public string CloseTime { get; set; }

     
        public decimal AvgPrice { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}