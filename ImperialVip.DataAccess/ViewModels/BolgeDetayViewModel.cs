using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.DataAccess.ViewModels
{
    public class BolgeDetayViewModel
    {
        public int Id { get; set; }
        public int BolgeId { get; set; }
        public string BolgeAdi { get; set; }
        public string BolgeDetay { get; set; }
        public bool AlisNoktasiMi { get; set; }
        public float Fiyat { get; set; }
        public string ResimUrl { get; set; }
        public int AracId { get; set; }
        public string AracAdi { get; set; }

    }
}
