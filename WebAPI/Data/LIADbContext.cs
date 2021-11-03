using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAPI.Entities;

#nullable disable

namespace WebAPI.Data
{
    public partial class LIADbContext : DbContext
    {
        public LIADbContext()
        {
        }

        public LIADbContext(DbContextOptions<LIADbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppartmentMaintance> AppartmentMaintances { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<ContractApartment> ContractApartments { get; set; }
        public virtual DbSet<ContractParking> ContractParkings { get; set; }
        public virtual DbSet<ErrorReport> ErrorReports { get; set; }
        public virtual DbSet<LaundryBooking> LaundryBookings { get; set; }
        public virtual DbSet<LaundryRoom> LaundryRooms { get; set; }
        public virtual DbSet<ParkingCategory> ParkingCategories { get; set; }
        public virtual DbSet<ParkingLot> ParkingLots { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserMessage> UserMessages { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AppartmentMaintance>(entity =>
            {
                entity.ToTable("AppartmentMaintance");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ErrorDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppartmentMaintances)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appartmen__UserI__787EE5A0");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(e => e.BillExpire).HasColumnType("datetime");

                entity.Property(e => e.BillPeriod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bills__UserId__619B8048");
            });

            modelBuilder.Entity<ContractApartment>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ApartmentNumber)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ContractApartments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ContractA__UserI__693CA210");
            });

            modelBuilder.Entity<ContractParking>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.LotNumber)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ParkingCategoryNavigation)
                    .WithMany(p => p.ContractParkings)
                    .HasForeignKey(d => d.ParkingCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ContractP__Parki__6C190EBB");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.ContractParkings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ContractP__UserI__6D0D32F4");
            });

            modelBuilder.Entity<ErrorReport>(entity =>
            {
                entity.ToTable("ErrorReport");

                entity.Property(e => e.Categorie).HasMaxLength(100);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ErrorDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ErrorReports)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ErrorRepo__UserI__75A278F5");
            });

            modelBuilder.Entity<LaundryBooking>(entity =>
            {
                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.HasOne(d => d.LaundryRoomNavigation)
                    .WithMany(p => p.LaundryBookings)
                    .HasForeignKey(d => d.LaundryRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LaundryBo__Laund__71D1E811");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LaundryBookings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LaundryBo__UserI__72C60C4A");
            });

            modelBuilder.Entity<LaundryRoom>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ParkingCategory>(entity =>
            {
                entity.Property(e => e.ParkingCategory1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ParkingCategory");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.ParkingLotsNavigation)
                    .WithMany(p => p.ParkingCategories)
                    .HasForeignKey(d => d.ParkingLots)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ParkingCa__Parki__66603565");
            });

            modelBuilder.Entity<ParkingLot>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phonenumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Ssn)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Uhash).IsRequired();

                entity.Property(e => e.Usalt).IsRequired();
            });

            modelBuilder.Entity<UserMessage>(entity =>
            {
                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.MessageDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserMessages)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserMessa__UserI__5EBF139D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
