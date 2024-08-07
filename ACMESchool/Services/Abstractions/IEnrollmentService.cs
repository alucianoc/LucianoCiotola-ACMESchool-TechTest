using ACMESchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Services.Abstractions
{
    public interface IEnrollmentService
    {
        void EnrollStudent(int studentId, int courseId);
        IEnumerable<Enrollment> GetEnrollments();
    }
}
