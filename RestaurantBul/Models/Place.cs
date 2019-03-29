using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static RestaurantBul.Enums.Enums;

namespace RestaurantBul.Models
{
    public class Place
    {
        public int PlaceID { get; set; }

        [Display(Name = "Mekan Adı")]
        public string PlaceName { get; set; }

        [Display(Name = "Menü Resmi")]
        public string MenuPic { get; set; }
        public CategoryName CategoryName { get; set; }

        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "İlçe")]
        public string  County{ get; set; }

        [Display(Name = "İl")]
        public string City { get; set; }

        [Display(Name = "Açılış Saati")]
        public string OpenTime { get; set; }

        [Display(Name = "Kapanış Saati")]
        public string CloseTime { get; set; }

        [Display(Name = "Ortalama Tutar")]
        public decimal AvgPrice { get; set; }

        

        
        
        public virtual ICollection<Comment>Comment { get; set; }

       
    }
}