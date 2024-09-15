using ImperialVip.DataAccess.Entities;
using System.Data.Entity;

namespace ImperialVip.DataAccess
{
    public class ImperialDatabaseContext : DbContext
    {

        public ImperialDatabaseContext() : base("name=ImperialDatabaseContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ImperialDatabaseContext>());
        }

        public virtual DbSet<Arac> Araclar { get; set; }
        public virtual DbSet<BizUlasinMail> BizUlasinMailler { get; set; }
        public virtual DbSet<Bolge> Bolgeler { get; set; }
        public virtual DbSet<BolgeyeGoreAracFiyat> BolgeyeGoreAracFiyatlar { get; set; }
        public virtual DbSet<Dil> Diller { get; set; }
        public virtual DbSet<Icerik> Icerikler { get; set; }
        public virtual DbSet<IcerikKategori> IcerikKategoriler { get; set; }
        public virtual DbSet<Kullanici> Kullanicilar { get; set; }
        public virtual DbSet<Otel> Oteller { get; set; }
        public virtual DbSet<Rezervasyon> Rezervasyonlar { get; set; }
        public virtual DbSet<RezervasyonKisi> RezervasyonKisiler { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<Yorum> Yorumlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // BolgeyeGoreAracFiyat ve Arac arasındaki bire bir ilişki
            modelBuilder.Entity<BolgeyeGoreAracFiyat>()
                    .HasRequired(b => b.Arac)
                    .WithMany()
                    .HasForeignKey(b => b.AracId)
                    .WillCascadeOnDelete(false);

            // BolgeyeGoreAracFiyat ve Bolge arasındaki bire bir ilişki
            modelBuilder.Entity<BolgeyeGoreAracFiyat>()
                .HasRequired(b => b.Bolge)
                .WithMany()
                .HasForeignKey(b => b.BolgeId)
                .WillCascadeOnDelete(false);

            // Icerik ve Dil arasındaki çoka bir ilişki
            modelBuilder.Entity<Dil>()
                .HasMany(kategori => kategori.Icerikler)
                .WithRequired(icerik => icerik.Dil)
                .HasForeignKey(icerik => icerik.DilId)
                .WillCascadeOnDelete(false);

            // Icerik ve IcerikKategori arasındaki çoka bir ilişki
            modelBuilder.Entity<IcerikKategori>()
                .HasMany(kategori => kategori.Icerikler)
                .WithRequired(icerik => icerik.IcerikKategori)
                .HasForeignKey(icerik => icerik.IcerikKategoriId)
                .WillCascadeOnDelete(false);

            // Rezervasyon ve Arac arasındaki bire bir ilişki
            modelBuilder.Entity<Rezervasyon>()
                .HasRequired(r => r.Arac)
                .WithMany()
                .HasForeignKey(r => r.AracId)
                .WillCascadeOnDelete(false);

            // Rezervasyon ve AlisNoktasi (Bolge) arasındaki bire bir ilişki
            modelBuilder.Entity<Rezervasyon>()
                .HasRequired(r => r.AlisNoktasi)
                .WithMany()
                .HasForeignKey(r => r.AlisNoktasiId)
                .WillCascadeOnDelete(false);

            // Rezervasyon ve VarisNoktasi (Bolge) arasındaki bire bir ilişki
            modelBuilder.Entity<Rezervasyon>()
                .HasRequired(r => r.VarisNoktasi)
                .WithMany()
                .HasForeignKey(r => r.VarisNoktasiId)
                .WillCascadeOnDelete(false);
        }
    }
}
