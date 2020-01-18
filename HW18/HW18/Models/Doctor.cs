using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW18.Models
{
    public class Doctor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public ICollection<MedicalReport> MedicalReports { get; set; }
    }
}
