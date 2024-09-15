using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.DataAccess.Entities
{
    [Table("Oteller")]
    public class Otel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string OtelAdi { get; set; }
    }
}
