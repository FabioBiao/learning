using CloudCustomers.API.Controllers;
using CloudCustomers.API.Models;
using CloudCustomers.UnitTests.Fixtures;
using FluentAssertions; // for the should to work
using Microsoft.AspNetCore.Mvc; // for the OkObjectResult 
using Moq;

// task should have - using System.Threading.Tasks;

namespace CloudCustomers.UnitTests.Systems.Controllers;

public class TestUsersController
{
    [Fact] // test method
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        // Arrange     // var sut = new UsersController();
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            //.ReturnsAsync(new List<User>()
            //{
            //    new(){
            //        Id = 1,
            //        Name = "Jane",
            //        Address = new Address()
            //        {
            //            Street ="123 Main St",
            //            City = "Madison",
            //            ZipCode = "53704"
            //        },
            //        Email = "jade@example.com"
            //    }
            //});
            .ReturnsAsync(UsersFixture.GetTestUsers());
        var sut = new UsersController(mockUsersService.Object);

        // Act
        var result = (OkObjectResult)await sut.Get();

        // Assert
        result.StatusCode.Should().Be(200);

    }

    [Fact]
    public async Task Get_OnSuccess_InvokesUserServiceExactlyOnce()
    {
        // Arrange
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService.Setup(service => service.GetAllUsers()).ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUsersService.Object);

        // Act
        var result = await sut.Get(); // (OkObjectResult)

        // Assert
        mockUsersService.Verify(service => service.GetAllUsers(), Times.Once());
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfUsers()
    {
        // Arrange
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(UsersFixture.GetTestUsers());
        var sut = new UsersController(mockUsersService.Object);

        // Act
        var result = await sut.Get(); // (OkObjectResult)

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<User>>();  
    }

    [Fact]
    public async Task Get_OnNoUsersFound_Returns404()
    {
        // Arrange
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUsersService.Object);

        // Act
        var result = await sut.Get(); // (OkObjectResult)

        // Assert
        // result.Should().BeOfType<NotFoundObjectResult>()
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }


    // theory runs multiple times with params
    //[Theory]
    //[InlineData("foo")]
    //[InlineData("bar")]
    //public void Test2(string input)
    //{

    //}
}