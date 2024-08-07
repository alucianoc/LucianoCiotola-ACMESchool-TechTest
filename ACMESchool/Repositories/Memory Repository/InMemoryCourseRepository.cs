using ACMESchool.Models;
using ACMESchool.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Repositories.Memory_Repository
{
    public class InMemoryCourseRepository : ICourseRepository
    {
        private readonly List<Course> _courses = new List<Course>();
        private int _currentId = 1;

        public void AddCourse(Course course)
        {
            course.Id = _currentId++;
            _courses.Add(course);
        }

        public Course GetCourse(int id)
        {
            return _courses.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Course> GetCourses()
        {
            return _courses;
        }

        public IEnumerable<Course> GetCoursesBetweenDates(DateTime startDate, DateTime endDate)
        {
            return _courses.Where(c => c.StartDate >= startDate && c.EndDate <= endDate);
        }
    }
}
