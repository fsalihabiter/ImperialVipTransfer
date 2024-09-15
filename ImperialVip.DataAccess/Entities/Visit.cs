using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.DataAccess.Entities
{
    [Table("Visits")]
    public class Visit
    {
        [Key]
        public int Id { get; set; }
        public string IPAddress { get; set; }
        public string UserAgent { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
