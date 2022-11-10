using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KizzowanieAPI
{
    public partial class KizzowanieDbContext : DbContext
    {
        public KizzowanieDbContext()
        {
        }

        public KizzowanieDbContext(DbContextOptions<KizzowanieDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BasicKizz> BasicKizz { get; set; }
        public virtual DbSet<Bkquestion> Bkquestion { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-UGLSJC1Q;Initial Catalog=KizzowanieDb;Integrated Security = true;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasicKizz>(entity =>
            {
                entity.Property(e => e.BasicKizzId).HasColumnName("BasicKizzID");

                entity.Property(e => e.BasicKizzIntro)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BasicKizzTitile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BkquestionId).HasColumnName("BKQuestionId");

                entity.Property(e => e.ImgName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bkquestion)
                    .WithMany(p => p.BasicKizz)
                    .HasForeignKey(d => d.BkquestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BasicKizz_BKQuestion");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BasicKizz)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_BasicKizz_Users");
            });

            modelBuilder.Entity<Bkquestion>(entity =>
            {
                entity.ToTable("BKQuestion");

                entity.Property(e => e.BkquestionId).HasColumnName("BKQuestionId");

                entity.Property(e => e.Bkanswer)
                    .HasColumnName("BKAnswer")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bkhint)
                    .HasColumnName("BKHint")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
