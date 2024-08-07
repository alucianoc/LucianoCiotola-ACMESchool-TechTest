using ACMESchool.Models;
using ACMESchool.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Repositories.Memory_Repository
{
    public class InMemoryStudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new List<Student>();
        private int _currentId = 1;

        public void AddStudent(Student student)
        {
            student.Id = _currentId++;
            _students.Add(student);
        }

        public Student GetStudent(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
