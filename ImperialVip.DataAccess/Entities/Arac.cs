namespace ImperialVip.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Araclar")]
    public partial class Arac
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string AracAdi { get; set; }
    }
}
