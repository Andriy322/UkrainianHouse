using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UkrainianHouse.Models;

#nullable disable

namespace UkrainianHouse.Data
{
    public partial class ConstructionCompany2Context : DbContext
    {
        public ConstructionCompany2Context()
        {
        }

        public ConstructionCompany2Context(DbContextOptions<ConstructionCompany2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounting> Accountings { get; set; }
        public virtual DbSet<BridgeEmployeeProject> BridgeEmployeeProjects { get; set; }
        public virtual DbSet<Date> Dates { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeView> EmployeeViews { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<ManagerView> ManagerViews { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectView> ProjectViews { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-DKTM405\\SQLEXPRESS; initial catalog = ConstructionCompany2;trusted_connection = yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Accounting>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__Accounti__85C600AF63C5F428");

                entity.ToTable("Accounting");

                entity.HasIndex(e => e.EmployeeId, "index3");

                entity.Property(e => e.TransactionId)
                    .ValueGeneratedNever()
                    .HasColumnName("transaction_id");

                entity.Property(e => e.DateId).HasColumnName("date_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.HasOne(d => d.Date)
                    .WithMany(p => p.Accountings)
                    .HasForeignKey(d => d.DateId)
                    .HasConstraintName("FK__Accountin__date___01142BA1");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Accountings)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Accountin__emplo__02084FDA");
            });

            modelBuilder.Entity<BridgeEmployeeProject>(entity =>
            {
                entity.HasKey(e => e.EmployeeProjectId)
                    .HasName("PK__BridgeEm__048B301EC419EE96");

                entity.ToTable("BridgeEmployeeProject");

                entity.Property(e => e.EmployeeProjectId).HasColumnName("employee_project_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.BridgeEmployeeProjects)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__BridgeEmp__emplo__19DFD96B");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.BridgeEmployeeProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__BridgeEmp__proje__1CBC4616");
            });

            modelBuilder.Entity<Date>(entity =>
            {
                entity.ToTable("Date");

                entity.Property(e => e.DateId)
                    .ValueGeneratedNever()
                    .HasColumnName("date_id");

                entity.Property(e => e.CalendarDate)
                    .HasColumnType("date")
                    .HasColumnName("calendar_date");

                entity.Property(e => e.Day).HasColumnName("day");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("employee_id");

                entity.Property(e => e.ActiveFlag).HasColumnName("active_flag");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("specialization");
            });

            modelBuilder.Entity<EmployeeView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EmployeeView");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CalendarDate)
                    .HasColumnType("date")
                    .HasColumnName("calendar_date");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("project_name");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("specialization");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ErrorLog");

                entity.Property(e => e.ErrorMessage).HasMaxLength(4000);

                entity.Property(e => e.ErrorProcedure).HasMaxLength(128);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationId)
                    .ValueGeneratedNever()
                    .HasColumnName("location_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("country");
            });

            modelBuilder.Entity<ManagerView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ManagerView");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CalendarDate)
                    .HasColumnType("date")
                    .HasColumnName("calendar_date");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.OperationId).HasColumnName("operation_id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("project_name");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.Property(e => e.MaterialId)
                    .ValueGeneratedNever()
                    .HasColumnName("material_id");

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("comments");

                entity.Property(e => e.MaterialName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("material_name");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.ToTable("Operation");

                entity.HasIndex(e => e.ProjectId, "index1");

                entity.HasIndex(e => e.MaterialId, "index2");

                entity.Property(e => e.OperationId)
                    .ValueGeneratedNever()
                    .HasColumnName("operation_id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.DateId).HasColumnName("date_id");

                entity.Property(e => e.MaterialId).HasColumnName("material_id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.HasOne(d => d.Date)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.DateId)
                    .HasConstraintName("FK__Operation__date___693CA210");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK__Operation__mater__68487DD7");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__Operation__proje__6754599E");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("project_name");

                entity.Property(e => e.ProjectStatus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("project_status");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Project__locatio__5DCAEF64");
            });

            modelBuilder.Entity<ProjectView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProjectView");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CalendarDate)
                    .HasColumnType("date")
                    .HasColumnName("calendar_date");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.MaterialName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("material_name");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("project_name");

                entity.Property(e => e.StorageId).HasColumnName("storage_id");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("status_id");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.ToTable("Storage");

                entity.Property(e => e.StorageId)
                    .ValueGeneratedNever()
                    .HasColumnName("storage_id");

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("comments");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.MaterialId).HasColumnName("material_id");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Storages)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Storage__materia__66603565");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.TaskId)
                    .ValueGeneratedNever()
                    .HasColumnName("task_id");

                entity.Property(e => e.EmpTaskInfo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("emp_task_info");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.TaskName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("task_name");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Task__employee_i__5AB9788F");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__Task__status_id__5BAD9CC8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
