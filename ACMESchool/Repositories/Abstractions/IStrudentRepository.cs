using ACMESchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Repositories.Abstractions
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        Student GetStudent(int id);
        IEnumerable<Student> GetStudents();
    }
}
