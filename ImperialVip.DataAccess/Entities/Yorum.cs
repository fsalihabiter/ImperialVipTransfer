using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.DataAccess.Entities
{
    [Table("Yorumlar")]
    public class Yorum
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string AdSoyad { get; set; }

        [Required]
        public string YorumDetay { get; set; }

        [Required]
        public int MemnuniyetOyu { get; set; }

        [Required]
        public DateTime YorumTarihi { get; set; }

        public bool OnayDurumu { get; set; }
    }
}
