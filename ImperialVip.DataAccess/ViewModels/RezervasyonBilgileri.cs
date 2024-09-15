using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.DataAccess.ViewModels
{
    public class KisiBilgi
    {
        public string AdSoyad { get; set; }
        public int YetiskinMi { get; set; }
    }

    public class RezervasyonBilgileri
    {
        public string OtelAdi { get; set; }
        public string AlisNoktasi { get; set; }
        public string VarisNoktasi { get; set; }
        public string AracId { get; set; }
        public string GelisZamani { get; set; }
        public string UcusNumarasi { get; set; }
        public bool DonusTransferi { get; set; }
        public string DonusZamani { get; set; }
        public string DonusUcusNumarasi { get; set; }
        public string YetiskinSayisi { get; set; }
        public string CocukSayisi { get; set; }
        public string CocukKoltuguSayisi { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string OzelNot { get; set; }
        public string DilKodu { get; set; }
        public string Fiyat { get; set; }
        public List<KisiBilgi> KisiBilgileri { get; set; }
    }
}
