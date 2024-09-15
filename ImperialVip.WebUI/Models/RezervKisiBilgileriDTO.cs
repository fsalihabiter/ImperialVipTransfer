using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImperialVip.WebUI.Models
{
    public class RezervKisiBilgileriDTO
    {

        [Required]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; }

        public bool YetiskinMi { get; set; }
    }
}