using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyBlogApp.Entities
{
    public partial class myblogsContext : DbContext
    {
        public myblogsContext()
        {
        }

        public myblogsContext(DbContextOptions<myblogsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blogsinfo> Blogsinfos { get; set; } = null!;
        public virtual DbSet<Classifyinfo> Classifyinfos { get; set; } = null!;
        public virtual DbSet<Labelinfo> Labelinfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=myblogs;uid=root;pwd=LJJ131115", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Blogsinfo>(entity =>
            {
                entity.HasKey(e => e.BlogId)
                    .HasName("PRIMARY");

                entity.ToTable("blogsinfo");

                entity.HasComment("博文信息表");

                entity.Property(e => e.BlogId).HasMaxLength(250);

                entity.Property(e => e.BlogTitle).HasMaxLength(250);

                entity.Property(e => e.Classify).HasMaxLength(100);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Creater).HasMaxLength(20);

                entity.Property(e => e.Label).HasMaxLength(100);
            });

            modelBuilder.Entity<Classifyinfo>(entity =>
            {
                entity.HasKey(e => e.ClassifyId)
                    .HasName("PRIMARY");

                entity.ToTable("classifyinfo");

                entity.HasComment("分类信息表");

                entity.Property(e => e.ClassifyId).HasMaxLength(250);

                entity.Property(e => e.ClassifyName).HasMaxLength(100);

                entity.Property(e => e.ParentClassifyId).HasMaxLength(250);
            });

            modelBuilder.Entity<Labelinfo>(entity =>
            {
                entity.HasKey(e => e.LabelId)
                    .HasName("PRIMARY");

                entity.ToTable("labelinfo");

                entity.HasComment("标签信息表");

                entity.Property(e => e.LabelId).HasMaxLength(250);

                entity.Property(e => e.LabelName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
