using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QuanLyNhanSu.Models
{
    public partial class QuanLyNhanSuContext : DbContext
    {
        public QuanLyNhanSuContext(DbContextOptions<QuanLyNhanSuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chucvu> Chucvus { get; set; }
        public virtual DbSet<DoanhthuNv> DoanhthuNvs { get; set; }
        public virtual DbSet<Hopdongld> Hopdonglds { get; set; }
        public virtual DbSet<HosoNv> HosoNvs { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<QuyenNv> QuyenNvs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:QuanLyNhanSu");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chucvu>(entity =>
            {
                entity.HasKey(e => e.Mscv)
                    .HasName("PK__CHUCVU__6CB235E5D70A01C7");

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

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TenCv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TenCV");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<DoanhthuNv>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__DOANHTHU__3213C8B7C82B93F6");

                entity.ToTable("DOANHTHU_NV");

                entity.Property(e => e.Ma).HasColumnName("ma");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DoanhThu).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.Msnv)
                    .HasMaxLength(10)
                    .HasColumnName("MSNV");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.MsnvNavigation)
                    .WithMany(p => p.DoanhthuNvs)
                    .HasForeignKey(d => d.Msnv)
                    .HasConstraintName("FK__DOANHTHU_N__MSNV__239E4DCF");
            });

            modelBuilder.Entity<Hopdongld>(entity =>
            {
                entity.HasKey(e => e.SoHd)
                    .HasName("PK__HOPDONGL__BC3CAB573D4FFAFD");

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

                entity.Property(e => e.Status).HasColumnName("status");

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
                    .HasConstraintName("FK__HOPDONGLD__MSCV__173876EA");

                entity.HasOne(d => d.MsnvNavigation)
                    .WithMany(p => p.Hopdonglds)
                    .HasForeignKey(d => d.Msnv)
                    .HasConstraintName("FK__HOPDONGLD__MSNV__182C9B23");
            });

            modelBuilder.Entity<HosoNv>(entity =>
            {
                entity.HasKey(e => e.Msnv)
                    .HasName("PK__HOSO_NV__6CB3885F2D11D926");

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

                entity.Property(e => e.Status).HasColumnName("status");

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
                    .HasConstraintName("FK__HOSO_NV__idlogin__1273C1CD");
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

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Quyen>(entity =>
            {
                entity.HasKey(e => e.MaQuyen)
                    .HasName("PK__QUYEN__1D4B7ED4FE18EB70");

                entity.ToTable("QUYEN");

                entity.Property(e => e.MaQuyen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MoTa)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<QuyenNv>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("QUYEN_NV");

                entity.Property(e => e.IdLogin).HasColumnName("idLogin");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.MaQuyen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdLogin)
                    .HasConstraintName("FK__QUYEN_NV__idLogi__267ABA7A");

                entity.HasOne(d => d.MaQuyenNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaQuyen)
                    .HasConstraintName("FK__QUYEN_NV__MaQuye__25869641");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
