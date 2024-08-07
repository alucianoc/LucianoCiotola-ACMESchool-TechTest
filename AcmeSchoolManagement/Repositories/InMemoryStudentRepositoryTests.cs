using System.Linq;
using Xunit;
using ACMESchool.Models;
using ACMESchool.Repositories.Memory_Repository;

public class InMemoryStudentRepositoryTests
{
    [Fact]
    public void AddStudent_ShouldAddStudentToList()
    {
        // Arrange
        var studentRepository = new InMemoryStudentRepository();
        var student = new Student { Name = "John Doe", Age = 20 };

        // Act
        studentRepository.AddStudent(student);

        // Assert
        var result = studentRepository.GetStudent(student.Id);
        Assert.NotNull(result);
        Assert.Equal(student.Id, result.Id);
        Assert.Single(studentRepository.GetStudents());
    }

    [Fact]
    public void GetStudent_ShouldReturnStudent_WhenStudentExists()
    {
        // Arrange
        var studentRepository = new InMemoryStudentRepository();
        var student = new Student { Name = "John Doe", Age = 20 };
        studentRepository.AddStudent(student);

        // Act
        var result = studentRepository.GetStudent(student.Id);

        // Assert
        Assert.Equal(student, result);
    }

    [Fact]
    public void GetStudent_ShouldReturnNull_WhenStudentDoesNotExist()
    {
        // Arrange
        var studentRepository = new InMemoryStudentRepository();

        // Act
        var result = studentRepository.GetStudent(1);

        // Assert
        Assert.Null(result);
    }
    [Fact]
    public void GetStudents_ShouldReturnAllStudents()
    {
        // Arrange
        var studentRepository = new InMemoryStudentRepository();
        studentRepository.AddStudent(new Student { Name = "John Doe", Age = 20 });
        studentRepository.AddStudent(new Student { Name = "Jane Doe", Age = 22 });

        // Act
        var result = studentRepository.GetStudents();

        // Assert
        Assert.Equal(2, result.Count());
    }
}