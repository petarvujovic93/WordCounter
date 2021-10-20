using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WordCounter.DataAccess.EF.Models;
using WordCounter.Extensions.Configuration;

#nullable disable

namespace WordCounter.DataAccess.EF.Context
{
    public partial class WordCounterContext : DbContext
    {
        private string ConnectionStringName = "WordCounter";
        public WordCounterContext()
        {
        }

        public WordCounterContext(DbContextOptions<WordCounterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Text> Texts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = ApiConfiguration.GetConnectionString(ConnectionStringName);
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Text>(entity =>
            {
                entity.ToTable("Texts", "WordCounter");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Text1)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("Text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
