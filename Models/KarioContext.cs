using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace tutorial.Models;

public partial class KarioContext : DbContext
{
    public KarioContext()
    {
    }

    public KarioContext(DbContextOptions<KarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Sentence> Sentences { get; set; }

    public virtual DbSet<Theme> Themes { get; set; }

    public virtual DbSet<ThemesWordsSentence> ThemesWordsSentences { get; set; }

    public virtual DbSet<ThemesWordsWord> ThemesWordsWords { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Word> Words { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=9999;user=root;password=root;database=kario", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("languages");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodLanguage)
                .HasMaxLength(2)
                .HasColumnName("cod_language");
            entity.Property(e => e.Language1)
                .HasMaxLength(20)
                .HasColumnName("language");
        });

        modelBuilder.Entity<Sentence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sentences");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Sentence1)
                .HasMaxLength(200)
                .HasColumnName("sentence");
            entity.Property(e => e.Translation)
                .HasMaxLength(200)
                .HasColumnName("translation");
        });

        modelBuilder.Entity<Theme>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("themes");

            entity.HasIndex(e => e.FkLanguage, "fk_language");

            entity.HasIndex(e => e.FkUser, "fk_user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.FkLanguage).HasColumnName("fk_language");
            entity.Property(e => e.FkUser).HasColumnName("fk_user");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.FkLanguageNavigation).WithMany(p => p.Themes)
                .HasForeignKey(d => d.FkLanguage)
                .HasConstraintName("themes_ibfk_2");

            entity.HasOne(d => d.FkUserNavigation).WithMany(p => p.Themes)
                .HasForeignKey(d => d.FkUser)
                .HasConstraintName("themes_ibfk_1");
        });

        modelBuilder.Entity<ThemesWordsSentence>(entity =>
        {
            entity.HasKey(e => new { e.FkTheme, e.FkSentence, e.FkWord })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("themes_words_sentences");

            entity.HasIndex(e => e.FkSentence, "fk_sentence");

            entity.HasIndex(e => e.FkWord, "fk_word");

            entity.Property(e => e.FkTheme).HasColumnName("fk_theme");
            entity.Property(e => e.FkSentence).HasColumnName("fk_sentence");
            entity.Property(e => e.FkWord).HasColumnName("fk_word");

            entity.HasOne(d => d.FkSentenceNavigation).WithMany(p => p.ThemesWordsSentences)
                .HasForeignKey(d => d.FkSentence)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("themes_words_sentences_ibfk_2");

            entity.HasOne(d => d.FkThemeNavigation).WithMany(p => p.ThemesWordsSentences)
                .HasForeignKey(d => d.FkTheme)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("themes_words_sentences_ibfk_1");

            entity.HasOne(d => d.FkWordNavigation).WithMany(p => p.ThemesWordsSentences)
                .HasForeignKey(d => d.FkWord)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("themes_words_sentences_ibfk_3");
        });

        modelBuilder.Entity<ThemesWordsWord>(entity =>
        {
            entity.HasKey(e => new { e.FkThemes, e.FkWord1, e.FkWord2 })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("themes_words_words");

            entity.HasIndex(e => e.FkWord1, "fk_word1");

            entity.HasIndex(e => e.FkWord2, "fk_word2");

            entity.Property(e => e.FkThemes).HasColumnName("fk_themes");
            entity.Property(e => e.FkWord1).HasColumnName("fk_word1");
            entity.Property(e => e.FkWord2).HasColumnName("fk_word2");

            entity.HasOne(d => d.FkThemesNavigation).WithMany(p => p.ThemesWordsWords)
                .HasForeignKey(d => d.FkThemes)
                .HasConstraintName("themes_words_words_ibfk_1");

            entity.HasOne(d => d.FkWord1Navigation).WithMany(p => p.ThemesWordsWordFkWord1Navigations)
                .HasForeignKey(d => d.FkWord1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("themes_words_words_ibfk_2");

            entity.HasOne(d => d.FkWord2Navigation).WithMany(p => p.ThemesWordsWordFkWord2Navigations)
                .HasForeignKey(d => d.FkWord2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("themes_words_words_ibfk_3");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Word>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("words");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Word1)
                .HasMaxLength(30)
                .HasColumnName("word");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
