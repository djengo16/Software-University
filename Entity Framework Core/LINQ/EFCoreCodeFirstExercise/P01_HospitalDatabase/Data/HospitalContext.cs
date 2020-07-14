using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options)
            :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=HospitalDatabase;Integrated Security=true;");
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PatientConfig(modelBuilder);

            VisitationConfig(modelBuilder);

            DiagnoseConfig(modelBuilder);

            MedicamentConfig(modelBuilder);
            
            //mapping
            PrescriptionConfig(modelBuilder);

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity
                .Property(d => d.Name)
                .IsUnicode(true)
                .IsRequired(true);

                entity
                .Property(d => d.Specialty)
                .IsUnicode(true)
                .IsRequired(true);
            });

        }

        private static void PrescriptionConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.MedicamentId,
                    e.PatientId
                });

                entity
                .HasOne(e => e.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(e => e.PatientId);

                entity
                .HasOne(e => e.Medicament)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(e => e.MedicamentId);
            });
        }

        private static void MedicamentConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicament>(entity =>
            {
                entity
                .Property(m => m.Name)
                .IsUnicode(true);

            });
        }

        private static void DiagnoseConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity
                .Property(d => d.Name)
                .IsUnicode(true)
                .IsRequired(true);

                entity
                .Property(d => d.Comments)
                .IsUnicode(true)
                .IsRequired(true);

                entity
                .HasOne(d => d.Patient)
                .WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.PatientId);

                entity
                .Property(d => d.PatientId);
            });
        }

        private static void VisitationConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.Property(v => v.Comments)
                .IsUnicode(true)
                .IsRequired(false);

                entity.HasOne(v => v.Patient)
                .WithMany(p => p.Visitations)
                .HasForeignKey(v => v.PatientId);

                entity.HasOne(v => v.Doctor)
                .WithMany(d => d.Visitations)
                .HasForeignKey(v => v.DoctorId);

                entity
                .Property(v => v.DoctorId)
                .IsRequired(false);
            });
        }

        private static void PatientConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity
                .Property(p => p.FirstName)
                .IsUnicode(true)
                .IsRequired(true);

                entity
                .Property(p => p.LastName)
                .IsUnicode(true)
                .IsRequired(true);

                entity
               .Property(p => p.Address)
               .IsUnicode(true)
               .IsRequired(true);

                entity
                .Property(p => p.Email)
                .IsUnicode(false)
                .IsRequired(true);

                entity
                .Property(p => p.HasInsurance)
                .IsRequired(true);

            });
        }
    }
}
