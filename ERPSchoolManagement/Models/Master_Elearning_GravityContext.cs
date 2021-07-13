using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class Master_Elearning_GravityContext : DbContext
    {
        public Master_Elearning_GravityContext()
        {
        }

        public Master_Elearning_GravityContext(DbContextOptions<Master_Elearning_GravityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblConnectionInfo> TblConnectionInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-7N92LNJ;Database=Master_Elearning_Gravity;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblConnectionInfo>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__Tbl_Conn__CA1FE464ECDE949C");

                entity.ToTable("Tbl_ConnectionInfo");

                entity.Property(e => e.FinancialYear)
                    .HasMaxLength(50)
                    .HasColumnName("Financial_Year");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.SchoolCode).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
