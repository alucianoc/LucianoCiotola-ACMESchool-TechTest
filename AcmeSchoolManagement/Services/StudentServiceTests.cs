using System;
using Xunit;
using Moq;
using ACMESchool.Models;
using ACMESchool.Repositories.Abstractions;
using ACMESchool.Services.Service;

public class StudentServiceTests
{
    [Fact]
    public void RegisterStudent_ShouldAddStudent_WhenValid()
    {
        // Arrange
        var studentRepositoryMock = new Mock<IStudentRepository>();
        var studentService = new StudentService(studentRepositoryMock.Object);

        // Act
        studentService.RegisterStudent("John Doe", 20);

        // Assert
        studentRepositoryMock.Verify(r => r.AddStudent(It.Is<Student>(s => s.Name == "John Doe" && s.Age == 20)), Times.Once);
    }

    [Fact]
    public void RegisterStudent_ShouldThrowException_WhenUnderage()
    {
        // Arrange
        var studentRepositoryMock = new Mock<IStudentRepository>();
        var studentService = new StudentService(studentRepositoryMock.Object);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => studentService.RegisterStudent("John Doe", 17));
    }

    [Fact]
    public void GetStudent_ShouldReturnStudent_WhenStudentExists()
    {
        // Arrange
        var studentRepositoryMock = new Mock<IStudentRepository>();
        var student = new Student { Id = 1, Name = "John Doe", Age = 20 };
        studentRepositoryMock.Setup(r => r.GetStudent(1)).Returns(student);
        var studentService = new StudentService(studentRepositoryMock.Object);

        // Act
        var result = studentService.GetStudent(1);

        // Assert
        Assert.Equal(student, result);
    }

    [Fact]
    public void GetStudent_ShouldReturnNull_WhenStudentDoesNotExist()
    {
        // Arrange
        var studentRepositoryMock = new Mock<IStudentRepository>();
        studentRepositoryMock.Setup(r => r.GetStudent(1)).Returns((Student)null);
        var studentService = new StudentService(studentRepositoryMock.Object);

        // Act
        var result = studentService.GetStudent(1);

        // Assert
        Assert.Null(result);
    }
}