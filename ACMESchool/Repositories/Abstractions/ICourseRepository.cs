using ACMESchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Repositories.Abstractions
{
    public interface ICourseRepository
    {
        void AddCourse(Course course); 
        IEnumerable<Course> GetCourses();
        IEnumerable<Course> GetCoursesBetweenDates(DateTime startDate, DateTime endDate);
        Course GetCourse(int id);
    }
}
