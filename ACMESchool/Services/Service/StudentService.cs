using ACMESchool.Models;
using ACMESchool.Repositories.Abstractions;
using ACMESchool.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Services.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void RegisterStudent(string name, int age)
        {
            if (age < 18)
            {
                throw new InvalidOperationException("Only adults can register.");
            }

            var student = new Student { Name = name, Age = age };
            _studentRepository.AddStudent(student);
        }

        public Student GetStudent(int id)
        {
            return _studentRepository.GetStudent(id);
        }
    }
}
