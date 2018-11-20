using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HydroApp.HDRM
{
    public partial class appContext : DbContext
    {
        public appContext()
        {
        }

        public appContext(DbContextOptions<appContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Boats> Boats { get; set; }
        public virtual DbSet<BoatSchedules> BoatSchedules { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<DayShedules> DayShedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("filename=/home/mangust/Hydro/HydroService/app.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boats>(entity =>
            {
                entity.HasKey(e => e.BoatId);

                entity.Property(e => e.BoatId).ValueGeneratedNever();
            });

            modelBuilder.Entity<BoatSchedules>(entity =>
            {
                entity.HasKey(e => e.ScheduleId);

                entity.HasIndex(e => e.BoatId);

                entity.Property(e => e.ScheduleId).ValueGeneratedNever();

                entity.Property(e => e.TimeEnd).IsRequired();

                entity.Property(e => e.TimeStart).IsRequired();

                entity.HasOne(d => d.Boat)
                    .WithMany(p => p.BoatSchedules)
                    .HasForeignKey(d => d.BoatId);
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientId).ValueGeneratedNever();

                entity.Property(e => e.ClientRegistred).IsRequired();
            });

            modelBuilder.Entity<DayShedules>(entity =>
            {
                entity.HasKey(e => e.DaySheduleId);

                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.DaySheduleId).ValueGeneratedNever();

                entity.Property(e => e.TimeEnd).IsRequired();

                entity.Property(e => e.TimeStart).IsRequired();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.DayShedules)
                    .HasForeignKey(d => d.ClientId);
            });
        }
    }
}
