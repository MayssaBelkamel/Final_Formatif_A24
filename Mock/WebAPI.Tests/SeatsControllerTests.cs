using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;
using WebAPI.Exceptions;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Tests;

[TestClass]
public class SeatsControllerTests
{
    [TestMethod]
    public void ReserveSeat_return_()
    {
        var serviceMock = new Mock<SeatsService>();

        // Mock du contrôleur pour pouvoir mocker UserId
        var controllerMock = new Mock<SeatsController>(serviceMock.Object);
        controllerMock.CallBase = true;
        controllerMock.Setup(c => c.UserId).Returns("user123");

        var controller = controllerMock.Object;

        var seat = new Seat { Number = 2 };

        serviceMock
            .Setup(s => s.ReserveSeat("user123", 2))
            .Returns(seat);

        var result = controller.ReserveSeat(2);

        var ok = result.Result as OkObjectResult;
        Assert.IsNotNull(ok);

 
    }

    [TestMethod]
    public void ReserveSeat_return_unauthorized()
    {
        var serviceMock = new Mock<SeatsService>();

        // Mock du contrôleur pour pouvoir mocker UserId
        var controllerMock = new Mock<SeatsController>(serviceMock.Object);
        controllerMock.CallBase = true;
        controllerMock.Setup(c => c.UserId).Returns("user123");

        var controller = controllerMock.Object;


        serviceMock
            .Setup(s => s.ReserveSeat("user123", 5))
            .Throws(new SeatAlreadyTakenException());

        var result = controller.ReserveSeat(5);

        var ok = result.Result as UnauthorizedResult;
        Assert.IsNotNull(ok);

    }

    [TestMethod]
    public void ReserveSeat_return_notFound()
    {
        var serviceMock = new Mock<SeatsService>();

        // Mock du contrôleur pour pouvoir mocker UserId
        var controllerMock = new Mock<SeatsController>(serviceMock.Object);
        controllerMock.CallBase = true;
        controllerMock.Setup(c => c.UserId).Returns("user123");

        var controller = controllerMock.Object;


        serviceMock
            .Setup(s => s.ReserveSeat("user123", 150))
            .Throws(new SeatOutOfBoundsException());

        var result = controller.ReserveSeat(150);

        var ok = result.Result as NotFoundResult;
        Assert.AreEqual("Could not find 150", (result.Result as NotFoundObjectResult)?.Value);
     //   Assert.IsNotNull(ok);

    }


    [TestMethod]
    public void ReserveSeat_return_badRequest()
    {
        var serviceMock = new Mock<SeatsService>();

        // Mock du contrôleur pour pouvoir mocker UserId
        var controllerMock = new Mock<SeatsController>(serviceMock.Object);
        controllerMock.CallBase = true;
        controllerMock.Setup(c => c.UserId).Returns("user123");

        var controller = controllerMock.Object;


        serviceMock
            .Setup(s => s.ReserveSeat("user123", 20))
            .Throws(new UserAlreadySeatedException());

        var result = controller.ReserveSeat(20);

        var ok = result.Result as BadRequestResult;
        
          Assert.IsNotNull(ok);

    }
}
