using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using ACMESchool.Models;
using ACMESchool.Repositories.Abstractions;
using ACMESchool.Services.Service;

public class CourseServiceTests
{
    [Fact]
    public void RegisterCourse_ShouldAddCourse_WhenValid()
    {
        // Arrange
        var courseRepositoryMock = new Mock<ICourseRepository>();
        var courseService = new CourseService(courseRepositoryMock.Object);
        var startDate = DateTime.Now;
        var endDate = DateTime.Now.AddDays(30);
        // Act
        courseService.RegisterCourse("Math 101", 100, startDate, endDate);

        // Assert
        courseRepositoryMock.Verify(repo => repo.AddCourse(It.Is<Course>(c => c.Name == "Math 101" && c.RegistrationFee == 100 && c.StartDate == startDate && c.EndDate == endDate)), Times.Once);
    }

    [Fact]
    public void GetCoursesBetweenDates_ShouldReturnCourses_WhenInRange()
    {
        // Arrange
        var courseRepositoryMock = new Mock<ICourseRepository>();
        var courses = new List<Course>
        {
            new Course { Id = 1, Name = "Math 101", StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddMonths(1) },
            new Course { Id = 2, Name = "History 101", StartDate = DateTime.Now.AddDays(2), EndDate = DateTime.Now.AddMonths(2) }
        };
        courseRepositoryMock.Setup(r => r.GetCoursesBetweenDates(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(courses);
        var courseService = new CourseService(courseRepositoryMock.Object);
        var startDate = DateTime.Now;
        var endDate = DateTime.Now.AddMonths(2);

        // Act
        var result = courseService.GetCoursesBetweenDates(startDate, endDate);

        // Assert
        Assert.Equal(courses, result);
    }

    [Fact]
    public void GetCourse_ShouldReturnCourse_WhenCourseExists()
    {
        // Arrange
        var courseRepositoryMock = new Mock<ICourseRepository>();
        var course = new Course { Id = 1, Name = "Math 101", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1) };
        courseRepositoryMock.Setup(r => r.GetCourse(1)).Returns(course);
        var courseService = new CourseService(courseRepositoryMock.Object);

        // Act
        var result = courseService.GetCourse(1);

        // Assert
        Assert.Equal(course, result);
    }

    [Fact]
    public void GetCourse_ShouldReturnNull_WhenCourseDoesNotExist()
    {
        // Arrange
        var courseRepositoryMock = new Mock<ICourseRepository>();
        courseRepositoryMock.Setup(r => r.GetCourse(1)).Returns((Course)null);
        var courseService = new CourseService(courseRepositoryMock.Object);

        // Act
        var result = courseService.GetCourse(1);

        // Assert
        Assert.Null(result);
    }
}