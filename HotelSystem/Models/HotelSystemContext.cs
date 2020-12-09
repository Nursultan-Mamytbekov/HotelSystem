using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HotelSystem
{
    public partial class HotelSystemContext : DbContext
    {
        public HotelSystemContext()
        {
        }

        public HotelSystemContext(DbContextOptions<HotelSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Number> Numbers { get; set; }
        public virtual DbSet<NumberType> NumberTypes { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<RpBooking> RpBookings { get; set; }
        public virtual DbSet<RpEmployee> RpEmployees { get; set; }
        public virtual DbSet<RpNumber> RpNumbers { get; set; }
        public virtual DbSet<RpSuggestion> RpSuggestions { get; set; }
        public virtual DbSet<RpTotalPrice> RpTotalPrices { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Suggestion> Suggestions { get; set; }
        public virtual DbSet<TotalPrice> TotalPrices { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-K0V0O3J\\SQLEXPRESS;Database=HotelSystem;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateOut)
                    .HasColumnType("date")
                    .HasColumnName("Date_Out");

                entity.Property(e => e.DateSet)
                    .HasColumnType("date")
                    .HasColumnName("Date_Set");

                entity.Property(e => e.IdClient).HasColumnName("ID_Client");

                entity.Property(e => e.IdNumber).HasColumnName("ID_Number");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK_Bookings_Clients");

                entity.HasOne(d => d.IdNumberNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.IdNumber)
                    .HasConstraintName("FK_Bookings_Numbers");

                entity.HasOne(d => d.ServiceNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Service)
                    .HasConstraintName("FK_Bookings_Services");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateRegister)
                    .HasColumnType("date")
                    .HasColumnName("Date_Register");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassportId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Passport_ID");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.PositionNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Position)
                    .HasConstraintName("FK_Employees_Positions");
            });

            modelBuilder.Entity<Number>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Numbers)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK_Numbers_Number_Types");
            });

            modelBuilder.Entity<NumberType>(entity =>
            {
                entity.ToTable("Number_Types");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Position1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Position");
            });

            modelBuilder.Entity<RpBooking>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Rp_Bookings");

                entity.Property(e => e.DateOut)
                    .HasColumnType("date")
                    .HasColumnName("Date_Out");

                entity.Property(e => e.DateSet)
                    .HasColumnType("date")
                    .HasColumnName("Date_Set");

                entity.Property(e => e.Expr1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RpEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Rp_Employees");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RpNumber>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Rp_Numbers");

                entity.Property(e => e.Expr1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RpSuggestion>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Rp_Suggestions");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Text)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RpTotalPrice>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Rp_Total_Prices");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SumPrice).HasColumnName("Sum_Price");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Suggestion>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Text)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClientNavigation)
                    .WithMany(p => p.Suggestions)
                    .HasForeignKey(d => d.Client)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Suggestions_Clients");
            });

            modelBuilder.Entity<TotalPrice>(entity =>
            {
                entity.ToTable("Total_Prices");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SumPrice).HasColumnName("Sum_Price");

                entity.HasOne(d => d.ClientNavigation)
                    .WithMany(p => p.TotalPrices)
                    .HasForeignKey(d => d.Client)
                    .HasConstraintName("FK_Total_Prices_Clients");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
