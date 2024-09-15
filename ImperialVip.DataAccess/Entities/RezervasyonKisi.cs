namespace ImperialVip.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RezervasyonKisiler")]
    public partial class RezervasyonKisi
    {
        [Key]
        public int Id { get; set; }

        public int RezervasyonId { get; set; }

        [Required]
        [StringLength(50)]
        public string AdSoyad { get; set; }

        public bool YetiskinMi { get; set; }

        public virtual Rezervasyon Rezervasyon { get; set; }
    }
}
