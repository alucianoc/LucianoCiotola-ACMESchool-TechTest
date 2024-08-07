using ACMESchool.Models;
using ACMESchool.Services.Abstractions;
using ACMESchool.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Services.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void RegisterCourse(string name, decimal registrationFee, DateTime startDate, DateTime endDate)
        {
            var course = new Course
            {
                Name = name,
                RegistrationFee = registrationFee,
                StartDate = startDate,
                EndDate = endDate
            };
            _courseRepository.AddCourse(course);
        }

        public IEnumerable<Course> GetCoursesBetweenDates(DateTime startDate, DateTime endDate)
        {
            return _courseRepository.GetCoursesBetweenDates(startDate, endDate);
        }

        public Course GetCourse(int id)
        {
            return _courseRepository.GetCourse(id);
        }

    }
}
