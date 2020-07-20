using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ecomITP390.Models
{
    public partial class ecomDBContext : DbContext
    {
        public ecomDBContext()
        {
        }

        public ecomDBContext(DbContextOptions<ecomDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthorityLevel> AuthorityLevel { get; set; }
        public virtual DbSet<Dispute> Dispute { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Governorate> Governorate { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<ReportTypes> ReportTypes { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceCategory> ServiceCategory { get; set; }
        public virtual DbSet<Shipment> Shipment { get; set; }
        public virtual DbSet<Transporter> Transporter { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=AMERAKRAD\\AMERAKSVU;Initial Catalog=ecomDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorityLevel>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dispute>(entity =>
            {
                entity.HasKey(e => e.Disputid);

                entity.ToTable("dispute");

                entity.Property(e => e.Disputid)
                    .HasColumnName("disputid")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArbiterId).HasColumnName("arbiterID");

                entity.Property(e => e.FinishDate)
                    .HasColumnName("finishDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrederId).HasColumnName("orederID");

                entity.Property(e => e.Result)
                    .IsRequired()
                    .HasColumnName("result")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TimeToFinish).HasColumnType("datetime");

                entity.HasOne(d => d.Arbiter)
                    .WithMany(p => p.Dispute)
                    .HasForeignKey(d => d.ArbiterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKarbiterID");

                entity.HasOne(d => d.Oreder)
                    .WithMany(p => p.Dispute)
                    .HasForeignKey(d => d.OrederId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKorderNID");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.HasIndex(e => e.SocialInsuranceId)
                    .HasName("SocialInsuranceUN")
                    .IsUnique();

                entity.HasIndex(e => new { e.UserId, e.SocialInsuranceId })
                    .HasName("EMPINDEX");

                entity.Property(e => e.EmpId)
                    .HasColumnName("empID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Institute)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Qualfication)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SocialInsuranceId).HasColumnName("SocialInsuranceID");

                entity.Property(e => e.SupervisedBy).HasColumnName("SupervisedBY");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.AuthorityLevelNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.AuthorityLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKauthorityLevel");

                entity.HasOne(d => d.SupervisedByNavigation)
                    .WithMany(p => p.InverseSupervisedByNavigation)
                    .HasForeignKey(d => d.SupervisedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKemployee");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkUserinfo");
            });

            modelBuilder.Entity<Governorate>(entity =>
            {
                entity.HasKey(e => e.GovId);

                entity.Property(e => e.GovId)
                    .HasColumnName("govID")
                    .ValueGeneratedNever();

                entity.Property(e => e.GovName)
                    .HasColumnName("govName")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Login__F3DBC572230D9D94")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Login)
                    .HasForeignKey<Login>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKLogin");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => new { e.OrderId, e.UserId, e.ServiceId, e.ShippmentId, e.RatePoint })
                    .HasName("ORDERINDEX");

                entity.Property(e => e.OrderId)
                    .HasColumnName("Order_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CloseCode).HasColumnName("closeCode");

                entity.Property(e => e.FinishDate)
                    .HasColumnName("finishDate")
                    .HasColumnType("date");

                entity.Property(e => e.OrderStatus).HasColumnName("ORDER_status");

                entity.Property(e => e.ServiceId).HasColumnName("Service_ID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKserviceID");

                entity.HasOne(d => d.Shippment)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ShippmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKshipID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKorderuserID");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.ReportId)
                    .HasColumnName("Report_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmpId).HasColumnName("empID");

                entity.Property(e => e.Files).HasMaxLength(300);

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Report)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKemprepoID");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Report)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKrpotype");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Report)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKuserID");
            });

            modelBuilder.Entity<ReportTypes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(30);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.ServiceId)
                    .HasColumnName("Service_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CatId).HasColumnName("Cat_ID");

                entity.Property(e => e.DeliveryTime)
                    .HasColumnName("deliveryTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Desc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKcatuserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKserviceuserID");
            });

            modelBuilder.Entity<ServiceCategory>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.Property(e => e.CatId)
                    .HasColumnName("CatID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.HasIndex(e => new { e.ShipmentId, e.TransporterId })
                    .HasName("SHIPMENTINDEX");

                entity.Property(e => e.ShipmentId)
                    .HasColumnName("shipmentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Deliverylocation)
                    .HasColumnName("deliverylocation")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PickUpLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingDate).HasColumnType("date");

                entity.Property(e => e.ShippingFees).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TransporterId).HasColumnName("TransporterID");

                entity.HasOne(d => d.Transporter)
                    .WithMany(p => p.Shipment)
                    .HasForeignKey(d => d.TransporterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKshepoID");
            });

            modelBuilder.Entity<Transporter>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("transporter");

                entity.HasIndex(e => e.LicensId)
                    .HasName("licIDun")
                    .IsUnique();

                entity.HasIndex(e => e.VechileNo)
                    .HasName("VechNOun")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LicensId).HasColumnName("licensID");

                entity.Property(e => e.LicenseValidity).HasColumnType("date");

                entity.Property(e => e.VechileNo)
                    .IsRequired()
                    .HasColumnName("VechileNO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VechileType)
                    .IsRequired()
                    .HasColumnName("vechileType")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Transporter)
                    .HasForeignKey<Transporter>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKtransID");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.NatId);

                entity.HasIndex(e => new { e.NatId, e.Fname, e.Lname, e.BirthDate, e.Email, e.GovId })
                    .HasName("USERINDEX");

                entity.Property(e => e.NatId)
                    .HasColumnName("Nat_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("Birth_Date")
                    .HasColumnType("date");

                entity.Property(e => e.City).HasMaxLength(30);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fathername)
                    .IsRequired()
                    .HasColumnName("fathername")
                    .HasMaxLength(30);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Homelocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .HasMaxLength(30);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Gov)
                    .WithMany(p => p.UserInfo)
                    .HasForeignKey(d => d.GovId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_govID");

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.UserInfo)
                    .HasForeignKey(d => d.UserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUserType");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.UserTypeId)
                    .HasColumnName("UserTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descreption).HasMaxLength(30);
            });
        }
    }
}
