using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ImperialVip.DataAccess.ViewModels
{
    public class BolgeFiyatViewModel
    {
        [Display(Name = "Bölge")]
        public int BolgeId { get; set; }

        [Display(Name = "Bölge")]
        public IEnumerable<SelectListItem> Bolgeler { get; set; }

        [Display(Name = "Araç")]
        public int AracId { get; set; }

        [Display(Name = "Araç Türü")]
        public IEnumerable<SelectListItem> Araclar { get; set; }

        [Display(Name = "Fiyat")]
        public float Fiyat { get; set; }

    }
}
