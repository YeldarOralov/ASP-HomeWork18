using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW18.Models
{
    public class MedicalReport
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PatientId { get; set; }
        public virtual IdentityUser Patient { get; set; }
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public string Description { get; set; }
        public DateTime DateOfIssue { get; set; } = DateTime.Now;
    }
}
