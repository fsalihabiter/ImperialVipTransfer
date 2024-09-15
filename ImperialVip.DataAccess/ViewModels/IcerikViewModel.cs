using ImperialVip.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.DataAccess.ViewModels
{
    public class IcerikViewModel
    {
        public int Id { get; set; }

        public int IcerikKategoriId { get; set; }

        public string KategoriAdi { get; set; }

        public int DilId { get; set; }

        public string DilAdi { get; set; }

        public string IcerikBaslik { get; set; }

        public string IcerikDetay { get; set; }

        public string ResimUrl { get; set; }
    }
}
