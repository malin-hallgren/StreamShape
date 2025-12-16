using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StreamShape.Models;

namespace StreamShape.Data;

public partial class StreamShapeDbContext : DbContext
{
    public StreamShapeDbContext()
    {
    }

    public StreamShapeDbContext(DbContextOptions<StreamShapeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Episode> Episodes { get; set; }

    public virtual DbSet<EpisodeActor> EpisodeActors { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieActor> MovieActors { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Tvshow> Tvshows { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("connectionString"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.Actorid).HasName("PK__Actor__83335D3353CA1372");

            entity.ToTable("Actor");

            entity.Property(e => e.Actorid).HasColumnName("actorid");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Episode>(entity =>
        {
            entity.HasKey(e => e.Episodeid).HasName("PK__Episode__9C4D21A0FC3153AD");

            entity.ToTable("Episode");

            entity.Property(e => e.Episodeid).HasColumnName("episodeid");
            entity.Property(e => e.Episodenummer).HasColumnName("episodenummer");
            entity.Property(e => e.Episodetitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("episodetitle");
            entity.Property(e => e.Releasedate).HasColumnName("releasedate");
            entity.Property(e => e.Showid).HasColumnName("showid");

            entity.HasOne(d => d.Show).WithMany(p => p.Episodes)
                .HasForeignKey(d => d.Showid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Episode__showid__440B1D61");
        });

        modelBuilder.Entity<EpisodeActor>(entity =>
        {
            entity.HasKey(e => new { e.Episodeid, e.Actorid }).HasName("PK__Episode___B47E1473C8D8BC68");

            entity.ToTable("Episode_Actor");

            entity.Property(e => e.Episodeid).HasColumnName("episodeid");
            entity.Property(e => e.Actorid).HasColumnName("actorid");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("role");

            entity.HasOne(d => d.Actor).WithMany(p => p.EpisodeActors)
                .HasForeignKey(d => d.Actorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Episode_A__actor__4D94879B");

            entity.HasOne(d => d.Episode).WithMany(p => p.EpisodeActors)
                .HasForeignKey(d => d.Episodeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Episode_A__episo__4CA06362");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Genreid).HasName("PK__Genre__3C516A4AAA88718D");

            entity.ToTable("Genre");

            entity.Property(e => e.Genreid).HasColumnName("genreid");
            entity.Property(e => e.Genrename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("genrename");
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasKey(e => e.Mediaid).HasName("PK__Media__D270B03AFAE96C05");

            entity.Property(e => e.Mediaid).HasColumnName("mediaid");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Releasedate).HasColumnName("releasedate");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Movieid).HasName("PK__Movie__42EACB66A1C3DE8E");

            entity.ToTable("Movie");

            entity.Property(e => e.Movieid).HasColumnName("movieid");
            entity.Property(e => e.Mediaid).HasColumnName("mediaid");

            entity.HasOne(d => d.Media).WithMany(p => p.Movies)
                .HasForeignKey(d => d.Mediaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie__mediaid__398D8EEE");
        });

        modelBuilder.Entity<MovieActor>(entity =>
        {
            entity.HasKey(e => new { e.Movieid, e.Actorid }).HasName("PK__Movie_Ac__6AD9FEB5159BE227");

            entity.ToTable("Movie_Actor");

            entity.Property(e => e.Movieid).HasColumnName("movieid");
            entity.Property(e => e.Actorid).HasColumnName("actorid");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("role");

            entity.HasOne(d => d.Actor).WithMany(p => p.MovieActors)
                .HasForeignKey(d => d.Actorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Act__actor__49C3F6B7");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieActors)
                .HasForeignKey(d => d.Movieid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Act__movie__48CFD27E");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Ratingid).HasName("PK__Rating__2D2E08C17C3EC2B5");

            entity.ToTable("Rating");

            entity.Property(e => e.Ratingid).HasColumnName("ratingid");
            entity.Property(e => e.Stars).HasColumnName("stars");
        });

        modelBuilder.Entity<Tvshow>(entity =>
        {
            entity.HasKey(e => e.Showid).HasName("PK__TVShow__DFD8FB42722678E6");

            entity.ToTable("TVShow");

            entity.Property(e => e.Showid).HasColumnName("showid");
            entity.Property(e => e.Episodecount).HasColumnName("episodecount");
            entity.Property(e => e.Mediaid).HasColumnName("mediaid");
            entity.Property(e => e.Seasoncount).HasColumnName("seasoncount");

            entity.HasOne(d => d.Media).WithMany(p => p.Tvshows)
                .HasForeignKey(d => d.Mediaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TVShow__mediaid__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
