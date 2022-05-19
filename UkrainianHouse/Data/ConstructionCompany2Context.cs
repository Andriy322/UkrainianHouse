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

                entity.Property(e => e.TransactionId).ValueGeneratedNever();

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
                entity.Property(e => e.DateId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Specialization).IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeView>(entity =>
            {
                entity.ToView("EmployeeView");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.ProjectName).IsUnicode(false);

                entity.Property(e => e.Specialization).IsUnicode(false);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId).ValueGeneratedNever();

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);
            });

            modelBuilder.Entity<ManagerView>(entity =>
            {
                entity.ToView("ManagerView");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.ProjectName).IsUnicode(false);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.MaterialId).ValueGeneratedNever();

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.MaterialName).IsUnicode(false);
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.Property(e => e.OperationId).ValueGeneratedNever();

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
                entity.Property(e => e.ProjectName).IsUnicode(false);

                entity.Property(e => e.ProjectStatus).IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Project__locatio__5DCAEF64");
            });

            modelBuilder.Entity<ProjectView>(entity =>
            {
                entity.ToView("ProjectView");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.MaterialName).IsUnicode(false);

                entity.Property(e => e.ProjectName).IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusId).ValueGeneratedNever();

                entity.Property(e => e.StatusName).IsUnicode(false);
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.Property(e => e.StorageId).ValueGeneratedNever();

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Storages)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Storage__materia__66603565");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.TaskId).ValueGeneratedNever();

                entity.Property(e => e.EmpTaskInfo).IsUnicode(false);

                entity.Property(e => e.TaskName).IsUnicode(false);

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
