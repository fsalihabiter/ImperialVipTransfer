using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.DataAccess.ViewModels
{
    public class RezervasyonModel
    {
        public int Id { get; set; }

        public int AlisNoktasiId { get; set; }

        public string AlisNoktasiAdi { get; set; }

        public int VarisNoktasiId { get; set; }

        public string VarisNoktasiAdi { get; set; }

        public int AracId { get; set; }

        public string AracAdi { get; set; }

        public string OtelAdi { get; set; }

        public DateTime GelisTarihi { get; set; }

        public string GelisUcusNumarasi { get; set; }

        public DateTime? DonusTarihi { get; set; }

        public string DonusUcusNumarasi { get; set; }

        public string DilKodu { get; set; }

        public string KisiSayisi { get; set; }

        public int? CocukKoltuguSayisi { get; set; }

        public string AdSoyad { get; set; }

        public string Telefon { get; set; }

        public string Email { get; set; }

        public string OzelNot { get; set; }

        public string Fiyat { get; set; }

        public bool RezervasyonOnay { get; set; }

        public DateTime KayitTarihi { get; set; }
    }

}
