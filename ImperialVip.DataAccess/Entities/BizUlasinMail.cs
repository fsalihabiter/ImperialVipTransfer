namespace ImperialVip.DataAccess.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BizUlasinMailler")]
    public partial class BizUlasinMail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string AdSoyad { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefon { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        public string Mesaj { get; set; }

        public DateTime GonderimTarihi { get; set; }
    }
}
