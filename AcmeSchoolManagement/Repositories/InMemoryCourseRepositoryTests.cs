using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using ACMESchool.Repositories;
using ACMESchool.Models;
using ACMESchool.Repositories.Memory_Repository;

public class InMemoryCourseRepositoryTests
{
    [Fact]
    public void AddCourse_ShouldAddCourseToList()
    {
        // Arrange
        var courseRepository = new InMemoryCourseRepository();
        var course = new Course { Name = "Math 101", RegistrationFee = 100, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1) };

        // Act
        courseRepository.AddCourse(course);

        // Assert
        var result = courseRepository.GetCourse(course.Id);
        Assert.NotNull(result);
        Assert.Single(courseRepository.GetCourses());
        Assert.Equal(course.Id, result.Id);
    }

    [Fact]
    public void GetCourse_ShouldReturnCourse_WhenCourseExists()
    {
        // Arrange
        var courseRepository = new InMemoryCourseRepository();
        var course = new Course { Name = "Math 101", RegistrationFee = 100, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1) };
        courseRepository.AddCourse(course);

        // Act
        var result = courseRepository.GetCourse(course.Id);

        // Assert
        Assert.Equal(course, result);
    }

    [Fact]
    public void GetCourse_ShouldReturnNull_WhenCourseDoesNotExist()
    {
        // Arrange
        var courseRepository = new InMemoryCourseRepository();

        // Act
        var result = courseRepository.GetCourse(1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetCoursesBetweenDates_ShouldReturnCourses_WhenInRange()
    {
        // Arrange
        var courseRepository = new InMemoryCourseRepository();
        var course1 = new Course{Name = "Math",RegistrationFee = 100,StartDate = new DateTime(2023, 1, 1),EndDate = new DateTime(2023, 1, 31)};
        var course2 = new Course{Name = "Science",RegistrationFee = 200,StartDate = new DateTime(2023, 2, 1),EndDate = new DateTime(2023, 2, 28)}; 
        courseRepository.AddCourse(course1);
        courseRepository.AddCourse(course2);

        // Act
        var result = courseRepository.GetCoursesBetweenDates(new DateTime(2023, 1, 1), new DateTime(2023, 1, 31));

        // Assert
        Assert.Contains(course1, result);
        Assert.DoesNotContain(course2, result);
    }
}