using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace android.Models;

public partial class MusicappContext : DbContext
{
    public MusicappContext()
    {
    }

    public MusicappContext(DbContextOptions<MusicappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Albumn> Albumns { get; set; }

    public virtual DbSet<Baihat> Baihats { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }


    public virtual DbSet<Danhmuc> Danhmucs { get; set; }

    public virtual DbSet<Nghesi> Nghesis { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=musicapp;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Albumn>(entity =>
        {
            entity.HasKey(e => e.IdAlbumn).HasName("PK__albumn__FF9BB4288BFB37F0");

            entity.ToTable("albumn");

            entity.Property(e => e.IdAlbumn).HasColumnName("idAlbumn");
            entity.Property(e => e.IdBaiHat).HasColumnName("idBaiHat");
            entity.Property(e => e.IdNgheSi).HasColumnName("idNgheSi");
            entity.Property(e => e.NgaoTao).HasColumnName("ngaoTao");
            entity.Property(e => e.TenAlbumn)
                .HasMaxLength(255)
                .HasColumnName("tenAlbumn");
        });

        modelBuilder.Entity<Baihat>(entity =>
        {
            entity.HasKey(e => e.IdBaiHat).HasName("PK__baihat__BE2940D21675075B");

            entity.ToTable("baihat");

            entity.Property(e => e.IdBaiHat).HasColumnName("idBaiHat");
            entity.Property(e => e.HinhBaiHat)
                .HasMaxLength(255)
                .HasColumnName("hinhBaiHat");
            entity.Property(e => e.IdDanhMuc).HasColumnName("idDanhMuc");
            entity.Property(e => e.IdNgheSi).HasColumnName("idNgheSi");
            entity.Property(e => e.LinkBaiHat)
                .HasMaxLength(255)
                .HasColumnName("linkBaiHat");
            entity.Property(e => e.NgayPhatHanh).HasColumnName("ngayPhatHanh");
            entity.Property(e => e.TenBaiHat)
                .HasMaxLength(255)
                .HasColumnName("tenBaiHat");
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.HasKey(e => e.IdBanner).HasName("PK__banner__9EAD8FB17B7E3AC5");

            entity.ToTable("banner");

            entity.Property(e => e.IdBanner).HasColumnName("idBanner");
            entity.Property(e => e.HinhAnhBanner)
                .HasMaxLength(255)
                .HasColumnName("hinhAnhBanner");
            entity.Property(e => e.IdBaiHat).HasColumnName("idBaiHat");
            entity.Property(e => e.NoiDung)
                .HasMaxLength(255)
                .HasColumnName("noiDung");
        });


        modelBuilder.Entity<Danhmuc>(entity =>
        {
            entity.HasKey(e => e.IdDanhMuc).HasName("PK__danhmuc__927F187887C5F336");

            entity.ToTable("danhmuc");

            entity.Property(e => e.IdDanhMuc).HasColumnName("idDanhMuc");
            entity.Property(e => e.TenDanhMuc)
                .HasMaxLength(255)
                .HasColumnName("tenDanhMuc");
        });

        modelBuilder.Entity<Nghesi>(entity =>
        {
            entity.HasKey(e => e.IdNgheSi).HasName("PK__nghesi__B9B006BC03E482D8");

            entity.ToTable("nghesi");

            entity.Property(e => e.IdNgheSi).HasColumnName("idNgheSi");
            entity.Property(e => e.Avartar)
                .HasMaxLength(255)
                .HasColumnName("avartar");
            entity.Property(e => e.GioiThieu)
                .HasMaxLength(255)
                .HasColumnName("gioiThieu");
            entity.Property(e => e.TenNgheSi)
                .HasMaxLength(255)
                .HasColumnName("tenNgheSi");
        });



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
