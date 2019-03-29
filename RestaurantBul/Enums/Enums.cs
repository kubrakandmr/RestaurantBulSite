using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantBul.Enums
{
    public class Enums
    {
        public enum CategoryName
        {
            [Display(Name = "Kahvaltı")]
            [Description("Kahvaltı")]
            Kahvalti,
            [Display(Name = "Eğlenceye Çık")]
            [Description("Eğlenceye Çık")]
            EğlenceyeCik,
            [Display(Name = "Cafe'ye Git")]
            [Description("Cafe'ye Git")]
            CafeyeGit,
            [Display(Name = "Ye ve Kalk")]
            [Description("Ye ve Kalk")]
            YeveKalk,
            [Display(Name = "Yemek")]
            [Description("Yemek")]
            Yemek,
            EglenceyeCik
        }
    }
}