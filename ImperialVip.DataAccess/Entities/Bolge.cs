namespace ImperialVip.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bolgeler")]
    public partial class Bolge
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string BolgeAdi { get; set; }

        public string BolgeDetay { get; set; }

        [Required]
        public bool AlisNoktasiMi { get; set; }

        [Required]
        public string ResimUrl { get; set; }
    }
}
