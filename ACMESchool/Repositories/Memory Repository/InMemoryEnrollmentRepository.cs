using ACMESchool.Models;
using ACMESchool.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Repositories.Memory_Repository
{

    public class InMemoryEnrollmentRepository : IEnrollmentRepository
    {
        private readonly List<Enrollment> _enrollments = new();
        private int _nextId = 1; // Simple ID generator

        public void AddEnrollment(Enrollment enrollment)
        {
            enrollment.Id = _nextId++;
            _enrollments.Add(enrollment);
        }

        public Enrollment GetEnrollment(int id)
        {
            return _enrollments.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Enrollment> GetEnrollments()
        {
            return _enrollments;
        }

        public IEnumerable<Enrollment> GetEnrollmentsByStudent(int studentId)
        {
            return _enrollments.Where(e => e.StudentId == studentId);
        }

        public IEnumerable<Enrollment> GetEnrollmentsByCourse(int courseId)
        {
            return _enrollments.Where(e => e.CourseId == courseId);
        }

        public void RemoveEnrollment(int id)
        {
            var enrollment = GetEnrollment(id);
            if (enrollment != null)
            {
                _enrollments.Remove(enrollment);
            }
        }
    }

}
