using System;
using Xunit;
using Moq;
using ACMESchool.Models;
using ACMESchool.Payment_GateWay.Mock_Gateway.Abstractions;
using ACMESchool.Repositories.Abstractions;
using ACMESchool.Services.Service;

public class EnrollmentServiceTests
{
    [Fact]
    public void EnrollStudent_ShouldAddEnrollment_WhenPaymentSuccessful()
    {
        // Arrange
        var enrollmentRepositoryMock = new Mock<IEnrollmentRepository>();
        var studentRepositoryMock = new Mock<IStudentRepository>();
        var courseRepositoryMock = new Mock<ICourseRepository>();
        var paymentGatewayMock = new Mock<IPaymentGateway>();

        var student = new Student { Id = 1, Name = "John Doe", Age = 20 };
        var course = new Course { Id = 1, Name = "Math 101", RegistrationFee = 100, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1) };

        studentRepositoryMock.Setup(r => r.GetStudent(1)).Returns(student);
        courseRepositoryMock.Setup(r => r.GetCourse(1)).Returns(course);
        paymentGatewayMock.Setup(p => p.ProcessPayment(100)).Returns(true);

        var enrollmentService = new EnrollmentService(enrollmentRepositoryMock.Object, studentRepositoryMock.Object, courseRepositoryMock.Object, paymentGatewayMock.Object);

        // Act
        enrollmentService.EnrollStudent(1, 1);

        // Assert
        enrollmentRepositoryMock.Verify(r => r.AddEnrollment(It.Is<Enrollment>(e => e.StudentId == 1 && e.CourseId == 1)), Times.Once);
    }

    [Fact]
    public void EnrollStudent_ShouldThrowException_WhenPaymentFails()
    {
        // Arrange
        var enrollmentRepositoryMock = new Mock<IEnrollmentRepository>();
        var studentRepositoryMock = new Mock<IStudentRepository>();
        var courseRepositoryMock = new Mock<ICourseRepository>();
        var paymentGatewayMock = new Mock<IPaymentGateway>();

        var student = new Student { Id = 1, Name = "John Doe", Age = 20 };
        var course = new Course { Id = 1, Name = "Math 101", RegistrationFee = 100, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1) };

        studentRepositoryMock.Setup(r => r.GetStudent(1)).Returns(student);
        courseRepositoryMock.Setup(r => r.GetCourse(1)).Returns(course);
        paymentGatewayMock.Setup(p => p.ProcessPayment(100)).Returns(false);

        var enrollmentService = new EnrollmentService(enrollmentRepositoryMock.Object, studentRepositoryMock.Object, courseRepositoryMock.Object, paymentGatewayMock.Object);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => enrollmentService.EnrollStudent(1, 1));
    }
    [Fact]
    public void EnrollStudent_ShouldThrowException_WhenCourseNotFound()
    {
        // Arrange
        var studentRepositoryMock = new Mock<IStudentRepository>();
        var courseRepositoryMock = new Mock<ICourseRepository>();
        var enrollmentRepositoryMock = new Mock<IEnrollmentRepository>();
        var paymentGatewayMock = new Mock<IPaymentGateway>();

        var enrollmentService = new EnrollmentService(enrollmentRepositoryMock.Object, studentRepositoryMock.Object, courseRepositoryMock.Object, paymentGatewayMock.Object);

        studentRepositoryMock.Setup(repo => repo.GetStudent(1)).Returns(new Student { Id = 1, Name = "John Doe", Age = 20 });

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => enrollmentService.EnrollStudent(1, 1));
        Assert.Equal("Course not found.", exception.Message);
    }
    [Fact]
    public void GetEnrollments_ShouldReturnAllEnrollments()
    {
        // Arrange
        var studentRepositoryMock = new Mock<IStudentRepository>();
        var courseRepositoryMock = new Mock<ICourseRepository>();
        var enrollmentRepositoryMock = new Mock<IEnrollmentRepository>();
        var enrollments = new[] { new Enrollment { Id = 1, StudentId = 1, CourseId = 1 } };
        var paymentGatewayMock = new Mock<IPaymentGateway>();

        enrollmentRepositoryMock.Setup(repo => repo.GetEnrollments()).Returns(enrollments);

        var enrollmentService = new EnrollmentService(enrollmentRepositoryMock.Object, studentRepositoryMock.Object, courseRepositoryMock.Object, paymentGatewayMock.Object);

        // Act
        var result = enrollmentService.GetEnrollments();

        // Assert
        Assert.Equal(enrollments, result);
    }
}
