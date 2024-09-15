using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.DataAccess.Entities
{
    [Table("IcerikKategoriler")]
    public class IcerikKategori
    {
        public IcerikKategori()
        {
            Icerikler = new List<Icerik>();
        }

        [Key]
        public int Id { get; set; }
        public string KategoriAdi { get; set; }

        public string KategoriResimUrl { get; set; }

        public virtual ICollection<Icerik> Icerikler { get; set; }
    }
}
