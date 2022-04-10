using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TP17WaterAPI.Models
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

        public virtual DbSet<ShowerRecord> ShowerRecords { get; set; }
        public virtual DbSet<WaterData> WaterData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=tp17-water.database.windows.net;Initial Catalog=tp17;User ID=tp17;Password=fit5120-water;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ShowerRecord>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("PK__ShowerRe__FBDF78E97DB23333");

                entity.ToTable("ShowerRecord");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<WaterData>(entity =>
            {
                entity.HasKey(e => e.WaterId)
                    .HasName("PK__WaterDat__C4F18E8FDEA39844");

                entity.Property(e => e.Year).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
