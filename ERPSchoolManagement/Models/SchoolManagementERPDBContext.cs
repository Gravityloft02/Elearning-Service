using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class SchoolManagementERPDBContext : DbContext
    {
        //public static string GetConnectionString()
        //{
        //    return Startup.ConnectionString;
        //}
        public SchoolManagementERPDBContext()
        {
        }

        public SchoolManagementERPDBContext(DbContextOptions<SchoolManagementERPDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspnetApplications> AspnetApplications { get; set; }
        public virtual DbSet<AspnetMembership> AspnetMembership { get; set; }
        public virtual DbSet<AspnetPaths> AspnetPaths { get; set; }
        public virtual DbSet<AspnetPersonalizationAllUsers> AspnetPersonalizationAllUsers { get; set; }
        public virtual DbSet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUser { get; set; }
        public virtual DbSet<AspnetProfile> AspnetProfile { get; set; }
        public virtual DbSet<AspnetRoles> AspnetRoles { get; set; }
        public virtual DbSet<AspnetSchemaVersions> AspnetSchemaVersions { get; set; }
        public virtual DbSet<AspnetUsers> AspnetUsers { get; set; }
        public virtual DbSet<AspnetUsersInRoles> AspnetUsersInRoles { get; set; }
        public virtual DbSet<AspnetWebEventEvents> AspnetWebEventEvents { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<ClassStudent> ClassStudent { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<ExamResult> ExamResult { get; set; }
        public virtual DbSet<ExamType> ExamType { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Locality> Locality { get; set; }
        public virtual DbSet<Parent> Parent { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblStudent> TblStudent { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<UserRegistration> UserRegistration { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<VwAspnetApplications> VwAspnetApplications { get; set; }
        public virtual DbSet<VwAspnetMembershipUsers> VwAspnetMembershipUsers { get; set; }
        public virtual DbSet<VwAspnetProfiles> VwAspnetProfiles { get; set; }
        public virtual DbSet<VwAspnetRoles> VwAspnetRoles { get; set; }
        public virtual DbSet<VwAspnetUsers> VwAspnetUsers { get; set; }
        public virtual DbSet<VwAspnetUsersInRoles> VwAspnetUsersInRoles { get; set; }
        public virtual DbSet<VwAspnetWebPartStatePaths> VwAspnetWebPartStatePaths { get; set; }
        public virtual DbSet<VwAspnetWebPartStateShared> VwAspnetWebPartStateShared { get; set; }
        public virtual DbSet<VwAspnetWebPartStateUser> VwAspnetWebPartStateUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-7N92LNJ;Database=SchoolManagementERPDB;Trusted_Connection=True;");

                //var con = GetConnectionString();
                //optionsBuilder.UseSqlServer(con);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspnetApplications>(entity =>
            {
                entity.HasKey(e => e.ApplicationId)
                    .HasName("PK__aspnet_A__C93A4C98F15AD367")
                    .IsClustered(false);

                entity.ToTable("aspnet_Applications");

                entity.HasIndex(e => e.LoweredApplicationName, "UQ__aspnet_A__17477DE481D12D5D")
                    .IsUnique();

                entity.HasIndex(e => e.ApplicationName, "UQ__aspnet_A__309103313EE5E85F")
                    .IsUnique();

                entity.HasIndex(e => e.LoweredApplicationName, "aspnet_Applications_Index")
                    .IsClustered();

                entity.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ApplicationName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredApplicationName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspnetMembership>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__aspnet_M__1788CC4D84FF4744")
                    .IsClustered(false);

                entity.ToTable("aspnet_Membership");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredEmail }, "aspnet_Membership_index")
                    .IsClustered();

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredEmail).HasMaxLength(256);

                entity.Property(e => e.MobilePin)
                    .HasMaxLength(16)
                    .HasColumnName("MobilePIN");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PasswordAnswer).HasMaxLength(128);

                entity.Property(e => e.PasswordQuestion).HasMaxLength(256);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetMembership)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Me__Appli__3B75D760");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.AspnetMembership)
                    .HasForeignKey<AspnetMembership>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Me__UserI__3C69FB99");
            });

            modelBuilder.Entity<AspnetPaths>(entity =>
            {
                entity.HasKey(e => e.PathId)
                    .HasName("PK__aspnet_P__CD67DC58F250EDD7")
                    .IsClustered(false);

                entity.ToTable("aspnet_Paths");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredPath }, "aspnet_Paths_index")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.PathId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LoweredPath)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetPaths)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Pa__Appli__6D0D32F4");
            });

            modelBuilder.Entity<AspnetPersonalizationAllUsers>(entity =>
            {
                entity.HasKey(e => e.PathId)
                    .HasName("PK__aspnet_P__CD67DC599A5FACC6");

                entity.ToTable("aspnet_PersonalizationAllUsers");

                entity.Property(e => e.PathId).ValueGeneratedNever();

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.PageSettings)
                    .IsRequired()
                    .HasColumnType("image");

                entity.HasOne(d => d.Path)
                    .WithOne(p => p.AspnetPersonalizationAllUsers)
                    .HasForeignKey<AspnetPersonalizationAllUsers>(d => d.PathId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Pe__PathI__72C60C4A");
            });

            modelBuilder.Entity<AspnetPersonalizationPerUser>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__aspnet_P__3214EC06F8287D22")
                    .IsClustered(false);

                entity.ToTable("aspnet_PersonalizationPerUser");

                entity.HasIndex(e => new { e.PathId, e.UserId }, "aspnet_PersonalizationPerUser_index1")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => new { e.UserId, e.PathId }, "aspnet_PersonalizationPerUser_ncindex2")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.PageSettings)
                    .IsRequired()
                    .HasColumnType("image");

                entity.HasOne(d => d.Path)
                    .WithMany(p => p.AspnetPersonalizationPerUser)
                    .HasForeignKey(d => d.PathId)
                    .HasConstraintName("FK__aspnet_Pe__PathI__76969D2E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspnetPersonalizationPerUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__aspnet_Pe__UserI__778AC167");
            });

            modelBuilder.Entity<AspnetProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__aspnet_P__1788CC4CA4202D2D");

                entity.ToTable("aspnet_Profile");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.PropertyNames)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.PropertyValuesBinary)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.PropertyValuesString)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.AspnetProfile)
                    .HasForeignKey<AspnetProfile>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Pr__UserI__5070F446");
            });

            modelBuilder.Entity<AspnetRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__aspnet_R__8AFACE1B68B5B382")
                    .IsClustered(false);

                entity.ToTable("aspnet_Roles");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredRoleName }, "aspnet_Roles_index1")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredRoleName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetRoles)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Ro__Appli__59FA5E80");
            });

            modelBuilder.Entity<AspnetSchemaVersions>(entity =>
            {
                entity.HasKey(e => new { e.Feature, e.CompatibleSchemaVersion })
                    .HasName("PK__aspnet_S__5A1E6BC1C31CD919");

                entity.ToTable("aspnet_SchemaVersions");

                entity.Property(e => e.Feature).HasMaxLength(128);

                entity.Property(e => e.CompatibleSchemaVersion).HasMaxLength(128);
            });

            modelBuilder.Entity<AspnetUsers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__aspnet_U__1788CC4D331331F0")
                    .IsClustered(false);

                entity.ToTable("aspnet_Users");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredUserName }, "aspnet_Users_Index")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => new { e.ApplicationId, e.LastActivityDate }, "aspnet_Users_Index2");

                entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredUserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.MobileAlias).HasMaxLength(16);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetUsers)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Us__Appli__2B3F6F97");
            });

            modelBuilder.Entity<AspnetUsersInRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK__aspnet_U__AF2760AD5968B9F8");

                entity.ToTable("aspnet_UsersInRoles");

                entity.HasIndex(e => e.RoleId, "aspnet_UsersInRoles_index");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspnetUsersInRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Us__RoleI__5EBF139D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspnetUsersInRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Us__UserI__5DCAEF64");
            });

            modelBuilder.Entity<AspnetWebEventEvents>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__aspnet_W__7944C810392B6963");

                entity.ToTable("aspnet_WebEvent_Events");

                entity.Property(e => e.EventId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ApplicationPath).HasMaxLength(256);

                entity.Property(e => e.ApplicationVirtualPath).HasMaxLength(256);

                entity.Property(e => e.Details).HasColumnType("ntext");

                entity.Property(e => e.EventOccurrence).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.EventSequence).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.EventTime).HasColumnType("datetime");

                entity.Property(e => e.EventTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.EventType)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ExceptionType).HasMaxLength(256);

                entity.Property(e => e.MachineName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Message).HasMaxLength(1024);

                entity.Property(e => e.RequestUrl).HasMaxLength(1024);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityName).HasMaxLength(500);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_City_StateId");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassYear).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_Class_GradeId");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK_Class_SectionId");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Class_TeacherId");
            });

            modelBuilder.Entity<ClassStudent>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Class)
                    .WithMany()
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_ClassStudent_ClassId");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_ClassStudent_StudentId");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ExamDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.ExamType)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.ExamTypeId)
                    .HasConstraintName("FK_Exam_ExamTypeId");
            });

            modelBuilder.Entity<ExamResult>(entity =>
            {
                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.ExamResult)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_ExamResult_ExamId");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ExamResult)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_ExamResult_StudentId");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.ExamResult)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_ExamResult_SubjectId");
            });

            modelBuilder.Entity<ExamType>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.GradeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Locality>(entity =>
            {
                entity.Property(e => e.LocalityName).HasMaxLength(500);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Locality)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Locality_CityId");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Locality)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Locality_StateId");
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DateOfJoin).HasColumnType("date");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.LastLoginDate).HasColumnType("date");

                entity.Property(e => e.MobileNo).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(20);
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MobileNo).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.PrincipalName).HasMaxLength(500);

                entity.Property(e => e.SchoolName).HasMaxLength(500);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.School)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_School_CityId");

                entity.HasOne(d => d.Locality)
                    .WithMany(p => p.School)
                    .HasForeignKey(d => d.LocalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_School_LocalityId");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.School)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_School_StateId");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.Property(e => e.SectionName).HasMaxLength(2);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.StateName).HasMaxLength(500);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DateOfJoin).HasColumnType("date");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.LastLoginDate).HasColumnType("date");

                entity.Property(e => e.MobileNo).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(20);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Student_ParentId");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.SubjectName).HasMaxLength(100);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_Subject_GradeId");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__Tbl_Empl__CA1FE464A2C6B255");

                entity.ToTable("Tbl_Employee");

                entity.Property(e => e.AlternateMobno)
                    .HasMaxLength(20)
                    .HasColumnName("Alternate_MOBNO");

                entity.Property(e => e.Caste)
                    .HasMaxLength(100)
                    .HasColumnName("CASTE");

                entity.Property(e => e.City).HasColumnName("CITY");

                entity.Property(e => e.Class).HasMaxLength(50);

                entity.Property(e => e.DateOfAnniversary)
                    .HasMaxLength(100)
                    .HasColumnName("DateOf_Anniversary");

                entity.Property(e => e.DateOfEntry).HasColumnType("datetime");

                entity.Property(e => e.DateOfJoining)
                    .HasColumnType("datetime")
                    .HasColumnName("DateOf_Joining");

                entity.Property(e => e.Department).HasMaxLength(100);

                entity.Property(e => e.Designation).HasMaxLength(100);

                entity.Property(e => e.EmpId).HasColumnName("Emp_ID");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(500)
                    .HasColumnName("Father_Name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Grade).HasMaxLength(100);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsClassTeacher).HasDefaultValueSql("((0))");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(500)
                    .HasColumnName("Job_Title");

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(10)
                    .HasColumnName("Marital_Status");

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(20)
                    .HasColumnName("MobileNO");

                entity.Property(e => e.MotherName)
                    .HasMaxLength(500)
                    .HasColumnName("Mother_Name");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(100)
                    .HasColumnName("NATIONALITY");

                entity.Property(e => e.Religion)
                    .HasMaxLength(100)
                    .HasColumnName("RELIGION");

                entity.Property(e => e.Section).HasMaxLength(10);

                entity.Property(e => e.SpouseName)
                    .HasMaxLength(100)
                    .HasColumnName("Spouse_Name");

                entity.Property(e => e.StaffType)
                    .HasMaxLength(500)
                    .HasColumnName("Staff_Type");

                entity.Property(e => e.State).HasColumnName("STATE");

                entity.Property(e => e.TeacherAddress).HasColumnName("Teacher_Address");

                entity.Property(e => e.TeacherDob)
                    .HasColumnType("datetime")
                    .HasColumnName("Teacher_DOB");

                entity.Property(e => e.TeacherImage).HasColumnName("Teacher_Image");

                entity.Property(e => e.TeacherName).HasColumnName("Teacher_Name");

                entity.Property(e => e.TeacherRegId)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TeacherReg_ID");
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.HasKey(e => e.Sno);

                entity.ToTable("Tbl_Student");

                entity.Property(e => e.Adharno)
                    .HasMaxLength(20)
                    .HasColumnName("ADHARNO");

                entity.Property(e => e.AdmNo)
                    .HasMaxLength(500)
                    .HasColumnName("ADM_NO");

                entity.Property(e => e.AllergyMedDesc).HasColumnName("ALLERGY_MED_DESC");

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(5)
                    .HasColumnName("BLOOD_GROUP");

                entity.Property(e => e.Caste)
                    .HasMaxLength(100)
                    .HasColumnName("CASTE");

                entity.Property(e => e.City).HasColumnName("CITY");

                entity.Property(e => e.Class)
                    .HasMaxLength(100)
                    .HasColumnName("CLASS");

                entity.Property(e => e.Dateofadmission)
                    .HasColumnType("datetime")
                    .HasColumnName("DATEOFADMISSION");

                entity.Property(e => e.EmgAddress).HasColumnName("EMG_ADDRESS");

                entity.Property(e => e.EmgMobno)
                    .HasMaxLength(20)
                    .HasColumnName("EMG_MOBNO");

                entity.Property(e => e.EmgPhoneno)
                    .HasMaxLength(20)
                    .HasColumnName("EMG_PHONENO");

                entity.Property(e => e.FamilyDoc).HasColumnName("FAMILY_DOC");

                entity.Property(e => e.FathersAnnualincome)
                    .HasMaxLength(500)
                    .HasColumnName("FATHERS_ANNUALINCOME");

                entity.Property(e => e.FathersDesignation)
                    .HasMaxLength(100)
                    .HasColumnName("FATHERS_DESIGNATION");

                entity.Property(e => e.FathersDob)
                    .HasColumnType("datetime")
                    .HasColumnName("FATHERS_DOB");

                entity.Property(e => e.FathersEmail)
                    .HasMaxLength(100)
                    .HasColumnName("FATHERS_EMAIL");

                entity.Property(e => e.FathersMobno)
                    .HasMaxLength(20)
                    .HasColumnName("FATHERS_MOBNO");

                entity.Property(e => e.FathersName).HasColumnName("FATHERS_NAME");

                entity.Property(e => e.FathersOffaddress).HasColumnName("FATHERS_OFFADDRESS");

                entity.Property(e => e.FathersProfession)
                    .HasMaxLength(100)
                    .HasColumnName("FATHERS_PROFESSION");

                entity.Property(e => e.FathersResaddress).HasColumnName("FATHERS_RESADDRESS");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Height)
                    .HasMaxLength(100)
                    .HasColumnName("HEIGHT");

                entity.Property(e => e.Incaseofemgname).HasColumnName("INCASEOFEMGNAME");

                entity.Property(e => e.MedicalAddress).HasColumnName("MEDICAL_ADDRESS");

                entity.Property(e => e.MothersAnnualincome)
                    .HasMaxLength(500)
                    .HasColumnName("MOTHERS_ANNUALINCOME");

                entity.Property(e => e.MothersDesignation)
                    .HasMaxLength(100)
                    .HasColumnName("MOTHERS_DESIGNATION");

                entity.Property(e => e.MothersDob)
                    .HasColumnType("datetime")
                    .HasColumnName("MOTHERS_DOB");

                entity.Property(e => e.MothersEmail)
                    .HasMaxLength(100)
                    .HasColumnName("MOTHERS_EMAIL");

                entity.Property(e => e.MothersMobno)
                    .HasMaxLength(20)
                    .HasColumnName("MOTHERS_MOBNO");

                entity.Property(e => e.MothersName).HasColumnName("MOTHERS_NAME");

                entity.Property(e => e.MothersOffaddress).HasColumnName("MOTHERS_OFFADDRESS");

                entity.Property(e => e.MothersProfession)
                    .HasMaxLength(100)
                    .HasColumnName("MOTHERS_PROFESSION");

                entity.Property(e => e.MothersResaddress).HasColumnName("MOTHERS_RESADDRESS");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(100)
                    .HasColumnName("NATIONALITY");

                entity.Property(e => e.Relation)
                    .HasMaxLength(100)
                    .HasColumnName("RELATION");

                entity.Property(e => e.Religion)
                    .HasMaxLength(100)
                    .HasColumnName("RELIGION");

                entity.Property(e => e.SamgraId)
                    .HasMaxLength(100)
                    .HasColumnName("SAMGRA_ID");

                entity.Property(e => e.Section)
                    .HasMaxLength(10)
                    .HasColumnName("SECTION");

                entity.Property(e => e.SmsDetailaltmobno)
                    .HasMaxLength(20)
                    .HasColumnName("SMS_DETAILALTMOBNO");

                entity.Property(e => e.SmsDetailemail)
                    .HasMaxLength(500)
                    .HasColumnName("SMS_DETAILEMAIL");

                entity.Property(e => e.SmsDetailmobno)
                    .HasMaxLength(20)
                    .HasColumnName("SMS_DETAILMOBNO");

                entity.Property(e => e.SmsSendername)
                    .HasMaxLength(500)
                    .HasColumnName("SMS_SENDERNAME");

                entity.Property(e => e.State).HasColumnName("STATE");

                entity.Property(e => e.StudentAddress).HasColumnName("STUDENT_ADDRESS");

                entity.Property(e => e.StudentCategory)
                    .HasMaxLength(100)
                    .HasColumnName("STUDENT_CATEGORY");

                entity.Property(e => e.StudentDob)
                    .HasMaxLength(100)
                    .HasColumnName("STUDENT_DOB");

                entity.Property(e => e.StudentImage).HasColumnName("STUDENT_IMAGE");

                entity.Property(e => e.StudentName).HasColumnName("STUDENT_NAME");

                entity.Property(e => e.StudentRegNo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("STUDENT_REG_NO");

                entity.Property(e => e.StudentType)
                    .HasMaxLength(50)
                    .HasColumnName("STUDENT_TYPE");

                entity.Property(e => e.Timeofsync)
                    .HasColumnType("datetime")
                    .HasColumnName("TIMEOFSYNC");

                entity.Property(e => e.Weight)
                    .HasMaxLength(100)
                    .HasColumnName("WEIGHT");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK_Tbl_User1");

                entity.ToTable("Tbl_User");

                entity.Property(e => e.BrachId)
                    .HasMaxLength(50)
                    .HasColumnName("BRACH_ID");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("CITY");

                entity.Property(e => e.DeletePermission).HasColumnName("DELETE_PERMISSION");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FinancialYear)
                    .HasMaxLength(50)
                    .HasColumnName("FINANCIAL_YEAR");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(50)
                    .HasColumnName("Mobile_No");

                entity.Property(e => e.ModifyPermisson).HasColumnName("MODIFY_PERMISSON");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PrintPermission).HasColumnName("PRINT_PERMISSION");

                entity.Property(e => e.ReportPermission).HasColumnName("REPORT_PERMISSION");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.Userid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERID");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.Usertype)
                    .HasMaxLength(50)
                    .HasColumnName("USERTYPE");

                entity.Property(e => e.WebAppLoginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("webAppLoginTime");

                entity.Property(e => e.WebPermission)
                    .HasMaxLength(50)
                    .HasColumnName("Web_Permission");

                entity.Property(e => e.WindowsAppLoginTime).HasColumnType("datetime");

                entity.Property(e => e.WindowsPermission)
                    .HasMaxLength(50)
                    .HasColumnName("Windows_Permission");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DateOfJoin).HasColumnType("date");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.LastLoginDate).HasColumnType("date");

                entity.Property(e => e.MobileNo).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(20);
            });

            modelBuilder.Entity<UserRegistration>(entity =>
            {
                entity.Property(e => e.Pincode).HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.UserRegistration)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registration_CityId");

                entity.HasOne(d => d.Locality)
                    .WithMany(p => p.UserRegistration)
                    .HasForeignKey(d => d.LocalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registration_LocalityId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRegistration)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registration_RoleId");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.UserRegistration)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Registration_StateId");
            });

            modelBuilder.Entity<VwAspnetApplications>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_Applications");

                entity.Property(e => e.ApplicationName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredApplicationName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetMembershipUsers>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_MembershipUsers");

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredEmail).HasMaxLength(256);

                entity.Property(e => e.MobileAlias).HasMaxLength(16);

                entity.Property(e => e.MobilePin)
                    .HasMaxLength(16)
                    .HasColumnName("MobilePIN");

                entity.Property(e => e.PasswordAnswer).HasMaxLength(128);

                entity.Property(e => e.PasswordQuestion).HasMaxLength(256);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetProfiles>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_Profiles");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VwAspnetRoles>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_Roles");

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredRoleName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetUsers>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_Users");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredUserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.MobileAlias).HasMaxLength(16);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetUsersInRoles>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_UsersInRoles");
            });

            modelBuilder.Entity<VwAspnetWebPartStatePaths>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_WebPartState_Paths");

                entity.Property(e => e.LoweredPath)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<VwAspnetWebPartStateShared>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_WebPartState_Shared");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VwAspnetWebPartStateUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_WebPartState_User");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
