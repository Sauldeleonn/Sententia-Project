﻿using System;
using System.Collections.Generic;
using DataAccess.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Repository;

public partial class MusicalReviewsDbContext : DbContext
{
    private readonly IConfiguration _config;
    private readonly string _connectionString;

    public MusicalReviewsDbContext(IConfiguration config)
    {
        _config = config;
        _connectionString = config.GetConnectionString("DefaultConnection");
    }

    public MusicalReviewsDbContext(DbContextOptions<MusicalReviewsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlbumDetail> AlbumDetails { get; set; }

    public virtual DbSet<ArtitsDetail> ArtitsDetails { get; set; }

    public virtual DbSet<BandDetail> BandDetails { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Link> Links { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<MusicalElement> MusicalElements { get; set; }

    public virtual DbSet<MusicalElementType> MusicalElementTypes { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<ReportReason> ReportReasons { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SongDetail> SongDetails { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlbumDetail>(entity =>
        {
            entity.Property(e => e.MusicalElementId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ArtitsDetail>(entity =>
        {
            entity.Property(e => e.MusicalElementId).ValueGeneratedNever();
        });

        modelBuilder.Entity<BandDetail>(entity =>
        {
            entity.Property(e => e.MusicalElementId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Link>(entity =>
        {
            entity.HasOne(d => d.MusicalElement).WithMany(p => p.Links)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Link_MusicalElement");

            entity.HasOne(d => d.Platform).WithMany(p => p.Links)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Link_Platform");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.Property(e => e.Name).IsFixedLength();

            entity.HasMany(d => d.MusicalElements).WithMany(p => p.Lists)
                .UsingEntity<Dictionary<string, object>>(
                    "ListElement",
                    r => r.HasOne<MusicalElement>().WithMany()
                        .HasForeignKey("MusicalElementId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ListElement_MusicalElement"),
                    l => l.HasOne<List>().WithMany()
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ListElement_List"),
                    j =>
                    {
                        j.HasKey("ListId", "MusicalElementId");
                        j.ToTable("ListElement");
                    });

            entity.HasMany(d => d.Tags).WithMany(p => p.Lists)
                .UsingEntity<Dictionary<string, object>>(
                    "ListTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ListTag_Tag"),
                    l => l.HasOne<List>().WithMany()
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ListTag_List"),
                    j =>
                    {
                        j.HasKey("ListId", "TagId");
                        j.ToTable("ListTag");
                    });

            entity.HasMany(d => d.Users).WithMany(p => p.Lists)
                .UsingEntity<Dictionary<string, object>>(
                    "ListUser",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ListUser_User"),
                    l => l.HasOne<List>().WithMany()
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ListUser_List"),
                    j =>
                    {
                        j.HasKey("ListId", "UserId");
                        j.ToTable("ListUser");
                    });
        });

        modelBuilder.Entity<MusicalElement>(entity =>
        {
            entity.Property(e => e.MusicalElementId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.MusicalElementNavigation).WithOne(p => p.MusicalElement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MusicalElement_AlbumDetail");

            entity.HasOne(d => d.MusicalElement1).WithOne(p => p.MusicalElement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MusicalElement_ArtitsDetail");

            entity.HasOne(d => d.MusicalElement2).WithOne(p => p.MusicalElement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MusicalElement_BandDetail");

            entity.HasOne(d => d.MusicalElement3).WithOne(p => p.MusicalElement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MusicalElement_SongDetail");

            entity.HasOne(d => d.MusicalElementType).WithMany(p => p.MusicalElements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MusicalElement_MusicalElementType");

            entity.HasMany(d => d.Genres).WithMany(p => p.MusicalElements)
                .UsingEntity<Dictionary<string, object>>(
                    "ElementGenre",
                    r => r.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ElementGenre_Genre"),
                    l => l.HasOne<MusicalElement>().WithMany()
                        .HasForeignKey("MusicalElementId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ElementGenre_MusicalElement"),
                    j =>
                    {
                        j.HasKey("MusicalElementId", "GenreId");
                        j.ToTable("ElementGenre");
                    });

            entity.HasMany(d => d.Languages).WithMany(p => p.MusicalElements)
                .UsingEntity<Dictionary<string, object>>(
                    "ElementLanguage",
                    r => r.HasOne<Language>().WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ElementLanguage_Language"),
                    l => l.HasOne<MusicalElement>().WithMany()
                        .HasForeignKey("MusicalElementId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ElementLanguage_MusicalElement"),
                    j =>
                    {
                        j.HasKey("MusicalElementId", "LanguageId");
                        j.ToTable("ElementLanguage");
                    });

            entity.HasMany(d => d.Tags).WithMany(p => p.MusicalElements)
                .UsingEntity<Dictionary<string, object>>(
                    "ElementTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ElementTag_Tag"),
                    l => l.HasOne<MusicalElement>().WithMany()
                        .HasForeignKey("MusicalElementId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ElementTag_MusicalElement"),
                    j =>
                    {
                        j.HasKey("MusicalElementId", "TagId");
                        j.ToTable("ElementTag");
                        j.IndexerProperty<int>("TagId").HasColumnName("tagId");
                    });
        });

        modelBuilder.Entity<MusicalElementType>(entity =>
        {
            entity.Property(e => e.MusicalElementTypeId).ValueGeneratedNever();
            entity.Property(e => e.Name).IsFixedLength();
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasOne(d => d.ReportReason).WithMany(p => p.Reports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Report_ReportReason");

            entity.HasOne(d => d.User).WithMany(p => p.Reports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Report_User");

            entity.HasOne(d => d.Review).WithMany(p => p.Reports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Report_Review");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.MusicalElementId }).HasName("PK_Review_1");

            entity.HasOne(d => d.MusicalElement).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_MusicalElement");

            entity.HasOne(d => d.User).WithMany(p => p.ReviewsNavigation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_User");
        });

        modelBuilder.Entity<SongDetail>(entity =>
        {
            entity.Property(e => e.MusicalElementId).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");

            entity.HasMany(d => d.Reviews).WithMany(p => p.UserIdLikes)
                .UsingEntity<Dictionary<string, object>>(
                    "Like",
                    r => r.HasOne<Review>().WithMany()
                        .HasForeignKey("UserReviewId", "MusicalElementId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Like_Review"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserIdLikeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Like_User1"),
                    j =>
                    {
                        j.HasKey("UserIdLikeId", "UserReviewId", "MusicalElementId");
                        j.ToTable("Like");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
