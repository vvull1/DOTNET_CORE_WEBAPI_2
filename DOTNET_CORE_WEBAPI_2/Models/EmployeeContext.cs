using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_CORE_WEBAPI_2.Models;

public partial class EmployeeContext : DbContext
{
    public EmployeeContext()
    {
    }

    public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EducationalDetailsTable> EducationalDetailsTables { get; set; }

    public virtual DbSet<EmployeeTable> EmployeeTables { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<ErrorLog1> ErrorLogs1 { get; set; }

    public virtual DbSet<UserMaster> UserMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-3BL0EPH\\SQLEXPRESS;Database=Employee;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EducationalDetailsTable>(entity =>
        {
            entity.HasKey(e => e.EducationalDetailsId);

            entity.ToTable("Educational_Details_Table");

            entity.Property(e => e.EducationalDetailsId).HasColumnName("Educational_Details_Id");
            entity.Property(e => e.ActiveStatus).HasColumnName("Active_Status");
            entity.Property(e => e.Education)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.GradeObtained)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Grade_Obtained");
            entity.Property(e => e.PassingYear)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Passing_Year");
            entity.Property(e => e.University)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.EducationalDetailsTables)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Educational_Details_Table_Employee_Table");
        });

        modelBuilder.Entity<EmployeeTable>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.ToTable("Employee_Table");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName).HasMaxLength(50);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasKey(e => e.ErrorId);

            entity.ToTable("Error_Log");

            entity.Property(e => e.ErrorId).HasColumnName("Error_Id");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.ErrorMessage).HasColumnName("Error_Message");
            entity.Property(e => e.MethodName)
                .HasMaxLength(500)
                .HasColumnName("Method_Name");
            entity.Property(e => e.PageName)
                .HasMaxLength(500)
                .HasColumnName("Page_Name");
            entity.Property(e => e.StackTrace).HasColumnName("Stack_Trace");
        });

        modelBuilder.Entity<ErrorLog1>(entity =>
        {
            entity.HasKey(e => e.ErrorId);

            entity.ToTable("ErrorLog");

            entity.Property(e => e.ErrorId).HasColumnName("Error_Id");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.ErrorMessage).HasColumnName("Error_Message");
            entity.Property(e => e.MethodName)
                .HasMaxLength(500)
                .HasColumnName("Method_Name");
            entity.Property(e => e.PageName)
                .HasMaxLength(500)
                .HasColumnName("Page_Name");
            entity.Property(e => e.StackTrace).HasColumnName("Stack_Trace");
        });

        modelBuilder.Entity<UserMaster>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("User_Master");

            entity.Property(e => e.UserId).HasColumnName("User_Id");
            entity.Property(e => e.ActiveStatus).HasColumnName("Active_Status");
            entity.Property(e => e.FullName)
                .HasMaxLength(500)
                .HasColumnName("Full_Name");
            entity.Property(e => e.LastLoginDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Last_Login_DateTime");
            entity.Property(e => e.Password).HasMaxLength(500);
            entity.Property(e => e.UserName)
                .HasMaxLength(500)
                .HasColumnName("User_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
