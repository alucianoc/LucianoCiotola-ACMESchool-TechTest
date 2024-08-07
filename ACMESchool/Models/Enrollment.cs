using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Models
{
    public class Enrollment
    {
        public int Id { get; set; } // Unique identifier for the enrollment
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public bool IsPaid { get; set; }
        public DateTime EnrollmentDate { get; set; } // Optional: To track when the student enrolled
    }
}
