using ACMESchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Services.Abstractions
{
    public interface IStudentService
    {
        void RegisterStudent(string name, int age);
        Student GetStudent(int id);
    }
}
