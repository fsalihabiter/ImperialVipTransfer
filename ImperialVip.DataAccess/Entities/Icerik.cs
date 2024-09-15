namespace ImperialVip.DataAccess.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Icerikler")]
    public partial class Icerik
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IcerikKategoriId { get; set; }

        [Required]
        public int DilId { get; set; }

        [StringLength(250)]
        public string IcerikBaslik { get; set; }

        public string IcerikDetay { get; set; }

        public string ResimUrl { get; set; }

        [ForeignKey("IcerikKategoriId")]
        public virtual IcerikKategori IcerikKategori { get; set; }

        [ForeignKey("DilId")]
        public virtual Dil Dil { get; set; }
    }
}
