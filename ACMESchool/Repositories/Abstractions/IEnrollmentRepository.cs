using ACMESchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Repositories.Abstractions
{
    public interface IEnrollmentRepository
    {
        void AddEnrollment(Enrollment enrollment);
        Enrollment GetEnrollment(int id);
        IEnumerable<Enrollment> GetEnrollments();
        IEnumerable<Enrollment> GetEnrollmentsByStudent(int studentId);
        IEnumerable<Enrollment> GetEnrollmentsByCourse(int courseId);
        void RemoveEnrollment(int id);
    }
}
