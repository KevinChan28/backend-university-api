using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api_backend_university.ContextDB;

public partial class UniversityDb2Context : DbContext
{
    public UniversityDb2Context()
    {
    }

    public UniversityDb2Context(DbContextOptions<UniversityDb2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Assist> Assists { get; set; }

    public virtual DbSet<Career> Careers { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Inscription> Inscriptions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Assists__3214EC072CB12F09");

            entity.Property(e => e.DateAssist).HasColumnType("datetime");
            entity.Property(e => e.Days)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.EndTime).HasColumnType("datetime");

            entity.HasOne(d => d.Course).WithMany(p => p.Assists)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Assists__Student__5441852A");

            entity.HasOne(d => d.Student).WithMany(p => p.Assists)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Assists__Student__5535A963");
        });

        modelBuilder.Entity<Career>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Career__3214EC07C69FC5FE");

            entity.ToTable("Career");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Class__3214EC07DD24EF83");

            entity.ToTable("Class");

            entity.Property(e => e.Days)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.EndTime).HasColumnType("time")
            .HasConversion(
                v => v.ToTimeSpan(),
                v => TimeOnly.FromTimeSpan(v));
            entity.Property(e => e.StartTime).HasColumnType("time")
            .HasConversion(
                v => v.ToTimeSpan(),
                v => TimeOnly.FromTimeSpan(v)
                );

            entity.HasOne(d => d.Course).WithMany(p => p.Classes)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Class__TeacherId__5070F446");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classes)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__Class__TeacherId__5165187F");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Course__3214EC0737ED6550");

            entity.ToTable("Course");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Event).WithMany(p => p.Courses)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Course__EventId__46E78A0C");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC074EF0A969");

            entity.Property(e => e.DeliveredDate).HasColumnType("datetime");
            entity.Property(e => e.NameDocument)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Path)
                .HasMaxLength(800)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Documents)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Documents__UserI__4D94879B");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events__3214EC0751299571");

            entity.Property(e => e.CratedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grades__3214EC0717DFFDCB");

            entity.Property(e => e.Grade1)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Grade");
            entity.Property(e => e.Partial)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Grades)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__CourseId__49C3F6B7");

            entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__StudentI__4AB81AF0");
        });

        modelBuilder.Entity<Inscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inscript__3214EC0799D0DD13");

            entity.ToTable("Inscription");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Class).WithMany(p => p.Inscriptions)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inscripti__Class__5AEE82B9");

            entity.HasOne(d => d.Student).WithMany(p => p.Inscriptions)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Inscripti__Stude__59063A47");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC075E9E320A");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07795F7CE2");

            entity.ToTable("Student");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Telephone).HasMaxLength(20);

            entity.HasOne(d => d.Career).WithMany(p => p.Students)
                .HasForeignKey(d => d.CareerId)
                .HasConstraintName("FK__Students__Career__3C69FB99");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Students__UserId__3B75D760");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teacher__3BD019B6C66FAFAD");

            entity.ToTable("Teacher");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Telephone).HasMaxLength(20);

            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Teacher__UserId__4222D4EF");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07B199BE53");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Password)
                .HasMaxLength(800)
                .IsUnicode(false);

            entity.HasOne(d => d.Rol).WithMany(p => p.Users)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK_Users_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
