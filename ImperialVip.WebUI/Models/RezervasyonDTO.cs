using ImperialVip.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImperialVip.WebUI.Models
{
    public class RezervasyonDTO
    {
        [Display(Name = "Alış Noktası")]
        public int AlisNoktasiId { get; set; }

        public List<SelectListItem> AlisNoktasi { get; set; }

        [Display(Name = "Varış Noktası")]
        public int VarisNoktasiId { get; set; }

        public List<SelectListItem> VarisNoktasi { get; set; }

        [Display(Name = "Araç")]
        public int AracId { get; set; }

        public List<SelectListItem> Arac { get; set; }

        [Display(Name = "Otel Adı")]
        public string OtelAdi { get; set; }

        [Display(Name = "Geliş Zamanı")]
        public DateTime GelisZamani { get; set; }

        [Display(Name = "Uçuş Numarası")]
        public string UcusNumarasi { get; set; }

        [Display(Name = "Dönüş Zamanı")]
        public DateTime? DonusZamani { get; set; }

        [Display(Name = "Uçuş Numarası")]
        public string DonusUcusNumarasi { get; set; }

        [Display(Name = "Yetişkin Sayısı")]
        public int YetiskinSayisi { get; set; }

        [Display(Name = "Çocuk Sayısı")]
        public int? CocukSayisi { get; set; }

        [Display(Name = "Çocuk Koltuğu İstiyorum")]
        public int? CocukKoltuguSayisi { get; set; }

        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; }

        [Display(Name = "Telefon Numarası")]
        public string Telefon { get; set; }

        [Display(Name = "E-posta Adresi")]
        public string Email { get; set; }

        [Display(Name = "Özel Not")]
        public string OzelNot { get; set; }

        public ICollection<RezervasyonKisi> RezervasyonKisiler { get; set; }
    }
}