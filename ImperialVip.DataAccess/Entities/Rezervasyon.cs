namespace ImperialVip.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Rezervasyonlar")]
    public partial class Rezervasyon
    {
        [Key]
        public int Id { get; set; }

        public int AlisNoktasiId { get; set; }

        public int VarisNoktasiId { get; set; }

        public int AracId { get; set; }

        [StringLength(250)]
        public string OtelAdi { get; set; }

        public DateTime GelisTarihi { get; set; }

        [StringLength(20)]
        public string GelisUcusNumarasi { get; set; }

        public DateTime? DonusTarihi { get; set; }

        [StringLength(20)]
        public string DonusUcusNumarasi { get; set; }

        [StringLength(3)]
        public string DilKodu { get; set; }

        public int YetiskinSayisi { get; set; }

        public int? CocukSayisi { get; set; }

        public int? CocukKoltuguSayisi { get; set; }

        [Required]
        [StringLength(50)]
        public string AdSoyad { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefon { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        public string OzelNot { get; set; }

        [Required]
        public string Fiyat { get; set; }

        public bool RezervasyonOnay { get; set; }

        public DateTime KayitTarihi { get; set; }

        public virtual Arac Arac { get; set; }

        public virtual Bolge AlisNoktasi { get; set; }

        public virtual Bolge VarisNoktasi { get; set; }
    }
}
