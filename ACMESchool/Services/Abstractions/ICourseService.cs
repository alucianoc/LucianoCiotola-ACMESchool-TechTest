using ACMESchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Services.Abstractions
{
    public interface ICourseService
    {
        void RegisterCourse(string name, decimal registrationFee, DateTime startDate, DateTime endDate);
        IEnumerable<Course> GetCoursesBetweenDates(DateTime startDate, DateTime endDate);
        Course GetCourse(int id);
    }
}
