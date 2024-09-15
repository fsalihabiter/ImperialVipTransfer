namespace ImperialVip.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BolgeyeGoreAracFiyatlar")]
    public partial class BolgeyeGoreAracFiyat
    {
        [Key]
        public int Id { get; set; }

        public int BolgeId { get; set; }

        public int AracId { get; set; }

        public float Fiyat { get; set; }

        public virtual Arac Arac { get; set; }

        public virtual Bolge Bolge { get; set; }
    }
}
