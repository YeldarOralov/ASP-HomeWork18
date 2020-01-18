using System;
using System.Collections.Generic;
using System.Text;
using HW18.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HW18.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalReport> MedicanCertificates { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Doctor>().HasData(
                new Doctor
                {
                    FullName = "Alex M."
                },
                new Doctor
                {
                    FullName = "Mark A."
                }
            );
            builder.Entity<MedicalReport>().HasOne(d => d.Doctor).WithMany(m => m.MedicalReports).HasForeignKey(d => d.DoctorId);
            builder.Entity<MedicalReport>().HasOne(u => u.Patient);
        }
    }
}
