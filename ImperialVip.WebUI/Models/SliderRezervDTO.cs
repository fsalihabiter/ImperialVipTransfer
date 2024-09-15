using ImperialVip.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImperialVip.WebUI.Models
{
    public class SliderRezervDTO
    {

        [Display(Name = "Alış Noktası")]
        public int AlisNoktasiId { get; set; }

        [Display(Name = "Varış Noktası")]
        public int VarisNoktasiId { get; set; }

        [Display(Name = "Yetişkin Sayısı")]
        public int YetiskinSayisi { get; set; }

        [Display(Name = "Çocuk Sayısı")]
        public int? CocukSayisi { get; set; }

        public IEnumerable<SelectListItem> AlisNoktasi { get; set; }

        public IEnumerable<SelectListItem> VarisNoktasi { get; set; }
    }
}