using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantBul.Models
{
    public class AddPla
    {
        [Key]
        public int ID { get; set; }
        public int PlaceID { get; set; }
        public int AdditionalID { get; set; }
        public virtual Additional Additional { get; set; }
        public virtual Place Place { get; set; }
    }
}