using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.DataAccess.Entities
{
    [Table("Diller")]
    public class Dil
    {
        public Dil()
        {
            Icerikler = new List<Icerik>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(3)]
        public string DilKodu { get; set; }

        [Required]
        [StringLength(15)]
        public string DilAdi { get; set; }

        public virtual ICollection<Icerik> Icerikler { get; set; }

    }
}
