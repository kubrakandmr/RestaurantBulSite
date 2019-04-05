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

        public string Email { get; set; }

        public bool Otopark { get; set; }
        [Display(Name = "Deniz Kenarı")]
        public bool DenizKenari { get; set; }

        [Display(Name = "Dış Mekan")]
        public bool DisMekan { get; set; }

        [Display(Name = "İç Mekan")]
        public bool İcMekan { get; set; }

        [Display(Name = "Terası Var")]
        public bool TerasiVar { get; set; }

        [Display(Name = "Alkol Servis")]
        public bool AlkolServis { get; set; }

        [Display(Name = "Wifi")]
        public bool Wifi { get; set; }

        [Display(Name = "Online Rezervasyon")]
        public bool OnlineRezervasyon { get; set; }

        [Display(Name = "Kahvaltı")]
        public bool Kahvalti { get; set; }

        [Display(Name = "Gel Al")]
        public bool GelAl { get; set; }

        [Display(Name = "Hayvan Dostu")]
        public bool HayvanDostu { get; set; }

        [Display(Name = "Sigara Alanı")]
        public bool SigaraAlanı { get; set; }

        [Display(Name = "Paket Servis")]
        public bool PaketServis { get; set; }

        [Display(Name = "Tatlı ve Pasta")]
        public bool TatlivePasta { get; set; }

        [Display(Name = "Canlı Müzik")]
        public bool CanliMuzik { get; set; }

       
    }
}