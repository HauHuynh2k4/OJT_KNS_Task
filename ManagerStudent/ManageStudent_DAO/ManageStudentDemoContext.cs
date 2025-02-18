using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace ManageStudent_BO.Models
{
    public partial class ManageStudentDemoContext : DbContext
    {
        public ManageStudentDemoContext()
        {
        }
        public ManageStudentDemoContext(string connectionString)
        {
            this.Database.SetConnectionString(connectionString);
        }

        public ManageStudentDemoContext(DbContextOptions<ManageStudentDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

            return strConn;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_Vietnam.1252");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => new { e.Username, e.Email })
                    .HasName("account_pkey");

                entity.ToTable("account");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Classname)
                    .HasName("class_pkey");

                entity.ToTable("class");

                entity.Property(e => e.Classname)
                    .HasMaxLength(50)
                    .HasColumnName("classname");

                entity.Property(e => e.Studentcount)
                    .HasColumnName("studentcount")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Studentid).HasColumnName("studentid");

                entity.Property(e => e.Academicperformance)
                    .HasMaxLength(20)
                    .HasColumnName("academicperformance");

                entity.Property(e => e.Classname)
                    .HasMaxLength(50)
                    .HasColumnName("classname");

                entity.Property(e => e.Studentname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("studentname");

                entity.HasOne(d => d.ClassnameNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Classname)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("student_classname_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
