using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WaterAPI.Models
{
    public partial class tp17Context : DbContext
    {
        public tp17Context()
        {
        }

        public tp17Context(DbContextOptions<tp17Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<IotRecord> IotRecords { get; set; }
        public virtual DbSet<ShowerRecord> ShowerRecords { get; set; }
        public virtual DbSet<WaterData> WaterData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=tp17db.database.windows.net;Initial Catalog=tp17;User ID=tp17;Password=fit5120-water;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("Device");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Label).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<IotRecord>(entity =>
            {
                entity.ToTable("IotRecord");

                entity.Property(e => e.RecordDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ShowerRecord>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("PK__ShowerRe__FBDF78E9F62BC3BB");

                entity.ToTable("ShowerRecord");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<WaterData>(entity =>
            {
                entity.HasKey(e => e.WaterId)
                    .HasName("PK__WaterDat__C4F18E8F46049DA5");

                entity.Property(e => e.Year).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
