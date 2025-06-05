using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Nexus_Photography_API.DBContext.Entities.TableEntities;

namespace Nexus_Photography_API.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<ClientSay> ClientSays { get; set; }

    public virtual DbSet<ContactForm> ContactForms { get; set; }

    public virtual DbSet<CoupleFilm> CoupleFilms { get; set; }

    public virtual DbSet<CoupleStory> CoupleStories { get; set; }

    public virtual DbSet<CulturalWedding> CulturalWeddings { get; set; }

    public virtual DbSet<DestinationWedding> DestinationWeddings { get; set; }

    public virtual DbSet<MostPopularFilm> MostPopularFilms { get; set; }

    public virtual DbSet<MostPopularWedding> MostPopularWeddings { get; set; }

    public virtual DbSet<PhotoGallery> PhotoGalleries { get; set; }

    public virtual DbSet<PhotographyStyle> PhotographyStyles { get; set; }

    public virtual DbSet<Testimonial> Testimonials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=hustlehub.cfw6scimuwug.ap-south-1.rds.amazonaws.com,1433;Database=Nexus_Photography;User Id=hustlehub;Password=Manohares;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admin__3214EC0777423768");
        });

        modelBuilder.Entity<ClientSay>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClientSa__3214EC070ACA0D00");
        });

        modelBuilder.Entity<ContactForm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContactF__3214EC07C05A6A66");
        });

        modelBuilder.Entity<CoupleFilm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CoupleFi__3214EC07A6BB7E53");
        });

        modelBuilder.Entity<CoupleStory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CoupleSt__3214EC07FE0EDFF2");
        });

        modelBuilder.Entity<CulturalWedding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cultural__3214EC0709990AC6");
        });

        modelBuilder.Entity<DestinationWedding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Destinat__3214EC076789A695");
        });

        modelBuilder.Entity<MostPopularFilm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MostPopu__3214EC07C0C599F9");
        });

        modelBuilder.Entity<MostPopularWedding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MostPopu__3214EC0750E8EBC7");
        });

        modelBuilder.Entity<PhotoGallery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PhotoGal__3214EC0755E201B2");

            entity.Property(e => e.Category).HasDefaultValue("Wedding");
            entity.Property(e => e.Layout).HasDefaultValue("landscape");
        });

        modelBuilder.Entity<PhotographyStyle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Photogra__3214EC071FB56F05");

            entity.Property(e => e.Title).HasDefaultValue("landscape");
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Testimon__3214EC077BAB75C1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
