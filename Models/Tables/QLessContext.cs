using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Models.Tables
{
    public partial class QLessContext : DbContext
    {
        public QLessContext()
        {
        }

        public QLessContext(DbContextOptions<QLessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ref_classification> ref_classification { get; set; }
        public virtual DbSet<tbl_card_discount_map> tbl_card_discount_map { get; set; }
        public virtual DbSet<tbl_cardtypes> tbl_cardtypes { get; set; }
        public virtual DbSet<tbl_discounts> tbl_discounts { get; set; }
        public virtual DbSet<tbl_passenger> tbl_passenger { get; set; }
        public virtual DbSet<tbl_routefee_map> tbl_routefee_map { get; set; }
        public virtual DbSet<tbl_station> tbl_station { get; set; }
        public virtual DbSet<tbl_transactions> tbl_transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\Magenic\\Q-Less\\Data\\QLess.mdf;Initial Catalog=QLess;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ref_classification>(entity =>
            {
                entity.HasKey(e => e.ClassificationID)
                    .HasName("PK_tbl_classification");

                entity.Property(e => e.ClassificationID).ValueGeneratedNever();

                entity.Property(e => e.ClassificationName).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.RecID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<tbl_card_discount_map>(entity =>
            {
                entity.Property(e => e.DiscountID).IsUnicode(false);

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.tbl_card_discount_map)
                    .HasForeignKey(d => d.DiscountID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_card_discount_map_tbl_discounts");
            });

            modelBuilder.Entity<tbl_cardtypes>(entity =>
            {
                entity.HasKey(e => e.CardTypeID)
                    .HasName("PK_ref_cardtypes");

                entity.Property(e => e.CardTypeID).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.RecID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<tbl_discounts>(entity =>
            {
                entity.Property(e => e.DiscountID).IsUnicode(false);

                entity.Property(e => e.DiscountName).IsUnicode(false);

                entity.Property(e => e.DiscountType).IsUnicode(false);

                entity.Property(e => e.DiscountValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.RecID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<tbl_passenger>(entity =>
            {
                entity.Property(e => e.CardNumber).IsUnicode(false);

                entity.Property(e => e.ContactNumber).IsUnicode(false);

                entity.Property(e => e.CreatedTimestamp).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailAddress).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.RecID).ValueGeneratedOnAdd();

                entity.Property(e => e.SupportingID).IsUnicode(false);

                entity.HasOne(d => d.CardType)
                    .WithMany(p => p.tbl_passenger)
                    .HasForeignKey(d => d.CardTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_passenger_tbl_cardtypes1");

                entity.HasOne(d => d.Classification)
                    .WithMany(p => p.tbl_passenger)
                    .HasForeignKey(d => d.ClassificationID)
                    .HasConstraintName("FK_tbl_passenger_ref_classification");
            });

            modelBuilder.Entity<tbl_routefee_map>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.RecID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<tbl_station>(entity =>
            {
                entity.Property(e => e.StationID).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.RecID).ValueGeneratedOnAdd();

                entity.Property(e => e.StationNumber).IsUnicode(false);
            });

            modelBuilder.Entity<tbl_transactions>(entity =>
            {
                entity.Property(e => e.CardNumber).IsUnicode(false);

                entity.Property(e => e.StationID).IsUnicode(false);

                entity.Property(e => e.TypeOfEntry).IsUnicode(false);

                entity.HasOne(d => d.CardNumberNavigation)
                    .WithMany(p => p.tbl_transactions)
                    .HasForeignKey(d => d.CardNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_transactions_tbl_passenger_cardnumber");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.tbl_transactions)
                    .HasForeignKey(d => d.StationID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_transactions_tbl_transactions");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
