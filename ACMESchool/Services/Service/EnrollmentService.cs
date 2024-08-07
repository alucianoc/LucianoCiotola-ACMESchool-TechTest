using ACMESchool.Models;
using ACMESchool.Repositories.Abstractions;
using ACMESchool.Services.Abstractions;
using ACMESchool.Payment_GateWay.Mock_Gateway.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Services.Service
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IPaymentGateway _paymentGateway;

        public EnrollmentService(
            IEnrollmentRepository enrollmentRepository,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IPaymentGateway paymentGateway)
        {
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _paymentGateway = paymentGateway;
        }

        public void EnrollStudent(int studentId, int courseId)
        {
            var student = _studentRepository.GetStudent(studentId);
            var course = _courseRepository.GetCourse(courseId);

            if (student == null)
                throw new InvalidOperationException("Student not found.");
            if (course == null)
                throw new InvalidOperationException("Course not found.");
            if (course.RegistrationFee > 0 && !_paymentGateway.ProcessPayment(course.RegistrationFee))
            {
                throw new InvalidOperationException("Payment failed.");
            }

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                IsPaid = course.RegistrationFee == 0 || _paymentGateway.ProcessPayment(course.RegistrationFee),
                EnrollmentDate = DateTime.Now
            };

            _enrollmentRepository.AddEnrollment(enrollment);
        }
        public IEnumerable<Enrollment> GetEnrollments()
        {
            return _enrollmentRepository.GetEnrollments();
        }
    }
}
