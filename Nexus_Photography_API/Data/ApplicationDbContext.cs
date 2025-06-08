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
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=hustlehub.cfw6scimuwug.ap-south-1.rds.amazonaws.com,1433;Database=Nexus_Photography;User Id=hustlehub;Password=Manohares;TrustServerCertificate=True");
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admin__3214EC07DFA688FE");
        });

        modelBuilder.Entity<ClientSay>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClientSa__3214EC07EB8601A0");
        });

        modelBuilder.Entity<ContactForm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContactF__3214EC071EA9C7BF");
        });

        modelBuilder.Entity<CoupleFilm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CoupleFi__3214EC075426B7A5");
        });

        modelBuilder.Entity<CoupleStory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CoupleSt__3214EC070FED59DE");
        });

        modelBuilder.Entity<CulturalWedding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cultural__3214EC07FE946791");
        });

        modelBuilder.Entity<DestinationWedding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Destinat__3214EC07C0786399");
        });

        modelBuilder.Entity<MostPopularFilm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MostPopu__3214EC07D3612737");
        });

        modelBuilder.Entity<MostPopularWedding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MostPopu__3214EC078E087B47");
        });

        modelBuilder.Entity<PhotoGallery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PhotoGal__3214EC07302E8DC0");

            entity.Property(e => e.Category).HasDefaultValue("Wedding");
            entity.Property(e => e.Layout).HasDefaultValue("landscape");
        });

        modelBuilder.Entity<PhotographyStyle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Photogra__3214EC0701433A50");

            entity.Property(e => e.Title).HasDefaultValue("landscape");
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Testimon__3214EC07BC10AFB7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
