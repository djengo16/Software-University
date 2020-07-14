using System;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;


namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {

        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Config.connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnConfiguringStudent(modelBuilder);

            OnConfiguringCourse(modelBuilder);

            OnConfiguringResource(modelBuilder);

            OnConfiguringHomework(modelBuilder);

            modelBuilder
                .Entity<StudentCourse>(entity =>
                {
                    entity.HasKey(e => new { e.CourseId, e.StudentId });

                    entity.HasOne(e => e.Student)
                    .WithMany(s => s.CourseEnrollments)
                    .HasForeignKey(e => e.StudentId);

                    entity.HasOne(e => e.Course)
                    .WithMany(c => c.StudentsEnrolled)
                    .HasForeignKey(e => e.CourseId);
                });
        }

        private static void OnConfiguringHomework(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Homework>(entity =>
                {
                    entity.HasKey(e => e.CourseId);

                    entity.Property(e => e.Content)
                    .IsRequired();

                    entity.HasOne(e => e.Student)
                    .WithMany(s => s.HomeworkSubmissions);

                    entity.HasOne(e => e.Course)
                    .WithMany(c => c.HomeworkSubmissions);
                });
        }

        private static void OnConfiguringResource(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Resource>(entity =>
                {
                    entity.HasKey(e => e.CourseId);

                    entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode();

                    entity.Property(e => e.Url)
                    .IsUnicode(false);

                    entity.HasOne(e => e.Course)
                    .WithMany(c => c.Resources);

                });
        }

        private static void OnConfiguringCourse(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Course>(entity =>
                {
                    entity.HasKey(e => e.CourseId);

                    entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .IsUnicode()
                    .IsRequired();

                    entity.Property(e => e.Description)
                    .IsUnicode();


                });
        }

        private static void OnConfiguringStudent(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>(entity =>
                {
                    entity.HasKey(e => e.StudentId);

                    entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode()
                    .IsRequired();

                    entity.Property(e => e.PhoneNumber)
                    .HasColumnType("CHAR(10)");


                });
        }
    }

    public static class Config
    {
        public const string connection = "Server=.;Database=StudentSystem;Integrated Security=True;";
    }
}
