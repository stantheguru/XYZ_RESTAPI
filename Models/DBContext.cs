using Microsoft.EntityFrameworkCore;

namespace XYZ.Models

{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<FamilyBank_Payment> FamilyBank_Payments { get; set; }

        public virtual DbSet<XYZ_Payment> XYZ_Payments { get; set; }

        public virtual DbSet<Notification> Notifications { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=xyz");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");
              

                entity.Property(e => e.StudentID)
                
                .HasColumnType("int(11)");

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StudentEmail)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StudentMobile)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Course)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<FamilyBank_Payment>(entity =>
            {
                entity.ToTable("family_bank_payment");
                entity.HasKey(e => e.PaymentID);

                entity.Property(e => e.PaymentID)
                
                .HasColumnType("int(11)");
                

                entity.Property(e => e.StudentID).HasColumnType("int(11)");

                entity.Property(e => e.Amount).HasColumnType("float");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.BankChannel)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.NotificationChannel)
                   .IsRequired()
                   .HasMaxLength(200);

            });

            modelBuilder.Entity<XYZ_Payment>(entity =>
            {
                entity.ToTable("xyz_payment");
                entity.HasKey(e => e.PaymentID);

                entity.Property(e => e.PaymentID)

                .HasColumnType("int(11)");


                entity.Property(e => e.StudentID).HasColumnType("int(11)");

                entity.Property(e => e.Amount).HasColumnType("float");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.BankChannel)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.NotificationChannel)
                   .IsRequired()
                   .HasMaxLength(200);

            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("notification");
                entity.HasKey(e => e.NotificationID);

                entity.Property(e => e.NotificationID)

                .HasColumnType("int(11)");


                entity.Property(e => e.StudentID).HasColumnType("int(11)");

                entity.Property(e => e.PaymentID).HasColumnType("int(11)");

               

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(200);

               

            });

            OnModelCreatingPartial(modelBuilder);

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
