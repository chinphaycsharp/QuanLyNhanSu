using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QuanLyNhanSu.Models
{
    public partial class QuanLyNhanSuContext : DbContext
    {
        public QuanLyNhanSuContext()
        {
        }

        public QuanLyNhanSuContext(DbContextOptions<QuanLyNhanSuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chucvu> Chucvus { get; set; }
        public virtual DbSet<Hopdongld> Hopdonglds { get; set; }
        public virtual DbSet<HosoNv> HosoNvs { get; set; }
        public virtual DbSet<Login> Logins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=DESKTOP-MV5RJQ0;User ID=quangle;Password=123456;Database=QuanLyNhanSu;Integrated Security=True");
                optionsBuilder.UseSqlServer("Server=DESKTOP-S9FNGVF\\SQLEXPRESS;User ID=quangle;Password=07081999;Database=QuanLyNhanSu;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chucvu>(entity =>
            {
                entity.HasKey(e => e.Mscv)
                    .HasName("PK__CHUCVU__6CB235E5337593EF");

                entity.ToTable("CHUCVU");

                entity.Property(e => e.Mscv)
                    .HasMaxLength(10)
                    .HasColumnName("MSCV");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.MotaCv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MotaCV");

                entity.Property(e => e.Phucaptrachnhiem).HasColumnType("money");

                entity.Property(e => e.TenCv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TenCV");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Hopdongld>(entity =>
            {
                entity.HasKey(e => e.SoHd)
                    .HasName("PK__HOPDONGL__BC3CAB575A12F3D2");

                entity.ToTable("HOPDONGLD");

                entity.Property(e => e.SoHd)
                    .HasMaxLength(20)
                    .HasColumnName("SoHD");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DieukhoanHd)
                    .HasMaxLength(50)
                    .HasColumnName("DieukhoanHD");

                entity.Property(e => e.HesoluongCb).HasColumnName("HesoluongCB");

                entity.Property(e => e.LoaiHd)
                    .HasMaxLength(10)
                    .HasColumnName("LoaiHD")
                    .IsFixedLength(true);

                entity.Property(e => e.Mscv)
                    .HasMaxLength(10)
                    .HasColumnName("MSCV");

                entity.Property(e => e.Msnv)
                    .HasMaxLength(10)
                    .HasColumnName("MSNV");

                entity.Property(e => e.MucluongCb)
                    .HasColumnType("money")
                    .HasColumnName("MucluongCB");

                entity.Property(e => e.Tgianbatdau)
                    .HasColumnType("datetime")
                    .HasColumnName("TGianbatdau");

                entity.Property(e => e.Tgianketthuc)
                    .HasColumnType("datetime")
                    .HasColumnName("TGianketthuc");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.MscvNavigation)
                    .WithMany(p => p.Hopdonglds)
                    .HasForeignKey(d => d.Mscv)
                    .HasConstraintName("FK__HOPDONGLD__MSCV__3E52440B");

                entity.HasOne(d => d.MsnvNavigation)
                    .WithMany(p => p.Hopdonglds)
                    .HasForeignKey(d => d.Msnv)
                    .HasConstraintName("FK__HOPDONGLD__MSNV__3F466844");
            });

            modelBuilder.Entity<HosoNv>(entity =>
            {
                entity.HasKey(e => e.Msnv)
                    .HasName("PK__HOSO_NV__6CB3885FD60E0F67");

                entity.ToTable("HOSO_NV");

                entity.Property(e => e.Msnv)
                    .HasMaxLength(10)
                    .HasColumnName("MSNV");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Gioitinh)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.HotenNv)
                    .HasMaxLength(30)
                    .HasColumnName("HotenNV");

                entity.Property(e => e.Idlogin).HasColumnName("idlogin");

                entity.Property(e => e.Ngaycap).HasColumnType("datetime");

                entity.Property(e => e.Ngaysinh).HasColumnType("datetime");

                entity.Property(e => e.Noicap).HasMaxLength(50);

                entity.Property(e => e.QueQuan).HasMaxLength(50);

                entity.Property(e => e.SoCmtnd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SoCMTND")
                    .IsFixedLength(true);

                entity.Property(e => e.Sđt)
                    .HasMaxLength(50)
                    .HasColumnName("SĐT");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Điachithuongtru).HasMaxLength(50);

                entity.HasOne(d => d.IdloginNavigation)
                    .WithMany(p => p.HosoNvs)
                    .HasForeignKey(d => d.Idlogin)
                    .HasConstraintName("FK__HOSO_NV__idlogin__398D8EEE");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
