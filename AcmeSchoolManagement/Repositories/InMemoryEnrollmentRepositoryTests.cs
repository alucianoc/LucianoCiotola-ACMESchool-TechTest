using System.Linq;
using Xunit;
using ACMESchool.Models;
using ACMESchool.Repositories.Memory_Repository;

public class InMemoryEnrollmentRepositoryTests
{
    [Fact]
    public void AddEnrollment_ShouldAddEnrollmentToList()
    {
        // Arrange
        var enrollmentRepository = new InMemoryEnrollmentRepository();
        var enrollment = new Enrollment { StudentId = 1, CourseId = 1, EnrollmentDate = DateTime.Now };

        // Act
        enrollmentRepository.AddEnrollment(enrollment);

        // Assert
        var result = enrollmentRepository.GetEnrollments().FirstOrDefault();
        Assert.NotNull(result);
        Assert.Equal(enrollment.StudentId, result.StudentId); 
        Assert.Single(enrollmentRepository.GetEnrollments());
    }

    [Fact]
    public void GetEnrollments_ShouldReturnAllEnrollments()
    {
        // Arrange
        var enrollmentRepository = new InMemoryEnrollmentRepository();
        var enrollment1 = new Enrollment { StudentId = 1, CourseId = 1 , EnrollmentDate = DateTime.Now };
        var enrollment2 = new Enrollment { StudentId = 2, CourseId = 2 , EnrollmentDate = DateTime.Now };
        enrollmentRepository.AddEnrollment(enrollment1);
        enrollmentRepository.AddEnrollment(enrollment2);

        // Act
        var result = enrollmentRepository.GetEnrollments();

        // Assert
        Assert.Equal(2, result.Count());
    }
    [Fact]
    public void GetEnrollmentsByStudent_ShouldReturnEnrollmentsForStudent()
    {
        // Arrange
        var enrollmentRepository = new InMemoryEnrollmentRepository();
        var enrollment1 = new Enrollment { StudentId = 1, CourseId = 1, EnrollmentDate = DateTime.Now };
        var enrollment2 = new Enrollment { StudentId = 1, CourseId = 2, EnrollmentDate = DateTime.Now };
        var enrollment3 = new Enrollment { StudentId = 2, CourseId = 1, EnrollmentDate = DateTime.Now };
        enrollmentRepository.AddEnrollment(enrollment1);
        enrollmentRepository.AddEnrollment(enrollment2);
        enrollmentRepository.AddEnrollment(enrollment3);

        // Act
        var result = enrollmentRepository.GetEnrollmentsByStudent(1);

        // Assert
        Assert.Contains(enrollment1, result);
        Assert.Contains(enrollment2, result);
        Assert.DoesNotContain(enrollment3, result);
    }

    [Fact]
    public void GetEnrollmentsByCourse_ShouldReturnEnrollmentsForCourse()
    {
        // Arrange
        var enrollmentRepository = new InMemoryEnrollmentRepository();
        var enrollment1 = new Enrollment { StudentId = 1, CourseId = 1 , EnrollmentDate = DateTime.Now };
        var enrollment2 = new Enrollment { StudentId = 2, CourseId = 1 , EnrollmentDate = DateTime.Now };
        var enrollment3 = new Enrollment { StudentId = 1, CourseId = 2 , EnrollmentDate = DateTime.Now };
        enrollmentRepository.AddEnrollment(enrollment1);
        enrollmentRepository.AddEnrollment(enrollment2);
        enrollmentRepository.AddEnrollment(enrollment3);

        // Act
        var result = enrollmentRepository.GetEnrollmentsByCourse(1);

        // Assert
        Assert.Contains(enrollment1, result);
        Assert.Contains(enrollment2, result);
        Assert.DoesNotContain(enrollment3, result);
    }

    [Fact]
    public void RemoveEnrollment_ShouldRemoveEnrollment()
    {
        // Arrange
        var enrollmentRepository = new InMemoryEnrollmentRepository();
        var enrollment = new Enrollment { Id = 1, StudentId = 1, CourseId = 1 };
        enrollmentRepository.AddEnrollment(enrollment);

        // Act
        enrollmentRepository.RemoveEnrollment(1);

        // Assert
        var result = enrollmentRepository.GetEnrollment(1);
        Assert.Null(result);
    }
}