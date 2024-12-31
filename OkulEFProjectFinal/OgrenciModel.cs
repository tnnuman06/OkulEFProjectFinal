using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulEFProjectFinal
{
    public class OgrenciModel : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<Sinif> Siniflar { get; set; }
        public DbSet<OgrenciDers> OgrenciDersler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=OkulEFProjectFinal;Integrated Security=True;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ogrenci yapısı
            modelBuilder.Entity<Ogrenci>(entity =>
            {
                entity.Property(o => o.Ad).HasColumnType("varchar").IsRequired().HasMaxLength(20);
                entity.Property(o => o.Soyad).HasColumnType("varchar").IsRequired().HasMaxLength(30);
                entity.Property(o => o.Numara).HasColumnType("varchar").IsRequired().HasMaxLength(23);
                entity.HasIndex(o => o.Numara).IsUnique();
            });

            // Ders yapısı
            modelBuilder.Entity<Ders>(entity =>
            {
                entity.Property(d => d.DersAd).HasColumnType("varchar").IsRequired().HasMaxLength(50);
                entity.Property(d => d.DersKod).IsRequired();
                entity.HasIndex(d => d.DersAd).IsUnique();
                entity.HasIndex(d => d.DersKod).IsUnique();
            });

            // Sinif yapısı
            modelBuilder.Entity<Sinif>(entity =>
            {
                entity.Property(s => s.SinifAd).IsRequired();
                entity.Property(s => s.Kontenjan).IsRequired();
                entity.HasIndex(s => s.SinifAd).IsUnique();
            });

            // OgrenciDers yapısı
            modelBuilder.Entity<OgrenciDers>(entity =>
            {
                entity.HasKey(od => new { od.DersId, od.OgrenciId });
                entity.HasOne(od => od.Ders).WithMany(d => d.OgrenciDersler).HasForeignKey(od => od.DersId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(od => od.Ogrenci).WithMany(o => o.OgrenciDersler).HasForeignKey(od => od.OgrenciId).OnDelete(DeleteBehavior.Cascade);
                entity.HasKey(od => new { od.DersId, od.OgrenciId });
            });
        }

    }

    public class Ogrenci
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Numara { get; set; }
        public int SinifId { get; set; }
        public virtual Sinif Sinif { get; set; }
        public virtual ICollection<OgrenciDers> OgrenciDersler { get; set; }

        public override string ToString()
        {
            return $"{this.Ad}-{this.Soyad}-{this.Numara}";
        }
    }
    public class Ders
    {
        public int DersId { get; set; }
        public string DersKod { get; set; }
        public string DersAd { get; set; }

        public virtual ICollection<OgrenciDers> OgrenciDersler { get; set; }
    }
    public class Sinif
    {
        public int SinifId { get; set; }
        public string SinifAd { get; set; }
        public int Kontenjan { get; set; }
        public virtual ICollection<Ogrenci> Ogrenciler { get; set; }
    }
    public class OgrenciDers
    {
        public int Id { get; set; }
        public int DersId { get; set; }
        public int OgrenciId { get; set; }

        public Ders Ders { get; set; }
        public Ogrenci Ogrenci { get; set; }
    }
}
